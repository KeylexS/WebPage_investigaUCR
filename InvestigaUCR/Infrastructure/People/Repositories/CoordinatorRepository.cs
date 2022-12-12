using Domain.People.DTOs;
using Domain.People.Entities;
using Domain.People.Repositories;
using Infrastructure.People.Context.Implementation;
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
    internal class CoordinatorRepository : PeopleRepository, ICoordinatorRepository
    {
        public CoordinatorRepository(GeneralDbContext unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Service to get the the list of all coordinators
        /// </summary>
        /// <returns>The list of people</returns>
        public async Task<IEnumerable<CoordinatorDto>> GetAllCoordinatorsAsync() 
        {
            return await _dbContext.Coordinators!
                .Select(t => new CoordinatorDto(t.GroupId, t.Id, t.Name, t.LastName1, t.LastName2, t.HighestDegree, t.University, t.ProfilePicture))
                .ToListAsync();
        }

        /// <summary>
        /// Service to Get a coordinator by an group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>One Coordinator by the groupId</returns>
        public async Task<Coordinator?> GetCoordinatorByGroupIdAsync(string groupId)
        {
            return await _dbContext.Coordinators.FirstOrDefaultAsync(x => x.GroupId == groupId);
        }

        public async Task SaveEntity(Coordinator entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
