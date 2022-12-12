using System;
using LanguageExt;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LanguageExt.Pretty;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using Domain.Core.Helpers;
using Domain.People.Entities;
using Domain.People.Relations;
using Domain.Core.ValueObjects;
using Domain.Core.Repositories;
using Domain.People.Repositories;
using Domain.ResearchGroups.DTOs;
using Infrastructure.People.Context.Implementation;
using Domain.ResearchGroups.ValueObjects;
using Domain.Publications.DTOs;

//ID US: PIIB22II02-59, task: PIIB22II02-299 Create repositories for people in infrastructure

namespace Infrastructure.People.Repositories
{
    /// <summary>
    /// Implementation of the IPeopleRepository
    /// </summary>
    public class PeopleRepository : IPeopleRepository
    {
        protected readonly GeneralDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PeopleRepository(GeneralDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
        /// Get a person by an id (email)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One Person by the id</returns>
        //PIIB22II02-190 MC-PL-2.3 Show publications associated with a person | task:  PIIB22II02-590 Create blazor component for the publication tab@
        public async Task<Person?> GetByIdAsync(string? id)
        {
            return await _dbContext.People
                .Include(r => r.ResearchProjects)
                .ThenInclude(a => a.ResearchAreas)
                .Include(m => m.MRResearchProjects)
                .Include(pb => pb.Publications)
                // PIIB22II02-524 MC-PL-2.7 Show thesis associated with a person | task: PIIB22II02-1030 Map relation in Infraestructure driver(JoseFNuñez), navigator(AndreyMena)
                .Include(t => t.Theses)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Get the the list of all people
        /// </summary>
        /// <returns>The list of people</returns>
        public async Task<IEnumerable<Person>?> GetAllAsync()
        {
            return await _dbContext.People.ToListAsync();
        }

        /// <summary>
        /// Get the a list of Groups of a Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The list of groups of a person</returns>
        // PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-569 Create interface method in domain for show groups by person. driver(AndreyMena), navigator(JoseFNuñez)
        public async Task<IEnumerable<GroupDTO>> GetGroupsByPersonID(string? id)
        {
            // The list of groups of a person
            IEnumerable<Composedby> groupListByPerson = _dbContext.Composed_by
                .Where(c => c.personalIdentification!.Equals(id))
                .ToList();
            // List of all groups
            IEnumerable<GroupDTO> allGroups = await _dbContext.Groups
                .Select(g => new GroupDTO(g.Id, g.Name, g.Description, g.Image))
                .ToListAsync();
            // Join of allGroups and Groups by Person
            IEnumerable<GroupDTO> groupsDTOsByPersonId = allGroups
                .Join(groupListByPerson, gAll => gAll.Id.Value, gList => gList.researchGroupID, (gAll, gList) => gAll)
                .ToList();

            // Return the list of groups
            return await Task.FromResult(groupsDTOsByPersonId);
        }

        public void DetachPerson(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Detached;
        }

        public async Task<Person?> GetByIdAsyncSingle(string id)
        {
            return await _dbContext.People.FindAsync(id);
        }

        //CRUDS
        public async Task CreatePerson(Person person)
        {
            _dbContext.Add(person);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task SaveAsync(Person person)
        {
            _dbContext.Update(person);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePerson(Person person)
        {
            _dbContext.Remove(person);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}

