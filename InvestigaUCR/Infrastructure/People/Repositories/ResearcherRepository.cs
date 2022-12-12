using Domain.People.DTOs;
using Domain.People.Entities;
using Domain.People.Repositories;
using Infrastructure.People.Context.Implementation;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.People.Repositories
{    
    // PIIB22II02-153 MC-PL-1.6 Organize card of the coordinator role in a research group Task : PIIB22II02-345 Add repository implementation
    internal class ResearcherRepository : PeopleRepository, IResearcherRepository
    {
        public ResearcherRepository(GeneralDbContext unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Service to get the the list of all researchers
        /// </summary>
        /// <returns>The list of people</returns>
        public async Task<IEnumerable<ResearcherDto>> GetAllResearchersAsync()
        {
            return await _dbContext.Researchers!
                .Select(t => new ResearcherDto(t.GroupId, t.Id, t.Name, t.LastName1, t.LastName2, t.HighestDegree, t.University, t.ProfilePicture))
                .ToListAsync();
        }

        /// <summary>
        /// Service to Get a researcher by an group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>One Coordinator by the groupId</returns>
        public async Task<IEnumerable<ResearcherDto>> GetResearchersByGroupIdAsync(string groupId)
        {
            // TODO Implementation of service list of researchers by group Id
            return await _dbContext.Researchers!.Where(x => x.GroupId == groupId)
                .Select(t => new ResearcherDto(t.GroupId, t.Id, t.Name, t.LastName1, t.LastName2, t.HighestDegree, t.University, t.ProfilePicture))
                .ToListAsync();
        }
    }
}
