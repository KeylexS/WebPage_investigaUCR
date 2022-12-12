using Domain.Core.Helpers;
using Domain.People.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.Repositories;
using Domain.ResearchProjects.ValueObjects;
using Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ResearchProjects.Repositories
{
    internal class ResearchProjectRepository : IResearchProjectsRepository
    {
        protected readonly GeneralDbContext _dbContext;

        public ResearchProjectRepository(GeneralDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ResearchProject>> GetAllAsync()
        {
            return await _dbContext.ResearchProject.OrderByDescending(s => s.Start_date).Include(x => x.ResearchAreas).ToListAsync();
        }

        public async Task<ResearchProject?> GetByIdAsync(string? id)
        {
            var Id = ResearchProjectId.TryCreate(id).Success();
            //TODO HANDLE EXCEPTION
            return await _dbContext.ResearchProject.Include(c => c.Collaborates.OrderBy(c => c.Orden)).Include(p => p.Publications).Include(x => x.ResearchAreas).Include(s => s.Theses).Include(m => m.MainResearcher).FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task SaveResearchProject(ResearchProject project)
        {
            _dbContext.Add(project);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task GeneralSaveResearchProject(ResearchProject project)
        {
            _dbContext.Update(project);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task DeleteResearchProject(ResearchProject project)
        {
            _dbContext.Remove(project);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsyncfromRP()
        {
            return await _dbContext.People.ToListAsync();
        }

        public async Task SaveCollab(Collaborate collab)
        {
            var aux = _dbContext.ResearchProject.FirstOrDefault(x => x.Id == collab.ResearchProjectsId);
            var ret = aux!.AddCollab(collab);
            if (ret)
            {
                _dbContext.Update(aux);
                await _dbContext.SaveEntitiesAsync();
            }
        }


        public async Task<IEnumerable<Group>> GetAllGroupWhitPublicationsAsync(int minYear, int maxYear)
        {
            _dbContext.ChangeTracker.Clear();
            return await _dbContext.Groups.Include(p => p.Publications.Where(p => p._Date.Year >= minYear).Where(p => p._Date.Year <= maxYear)).ToListAsync();
        }

        /// <summary>
        /// Method <c>SaveAsync</c> Saves the project instance into the database or updates the information of an existing row.
        /// </summary>
        /// <param name="project">The project instance to save</param>
        /// <returns></returns>
        public async Task SaveAsync(ResearchProject project)
        {
            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateResearchProject(ResearchProject project)
        {
            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }
    }
}
