using Domain.Core.Repositories;
using Domain.People.DTOs;
using Domain.People.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PIIB22II02-153 MC-PL-1.6 Organize card of the coordinator role in a research group Task: PIIB22II02-344 Add Repository interface
namespace Domain.People.Repositories
{
    public interface ICoordinatorRepository : IRepository<Coordinator>
    {
        /// <summary>
        /// Service to get the the list of all coordinators
        /// </summary>
        /// <returns>The list of people</returns>
        Task<IEnumerable<CoordinatorDto>> GetAllCoordinatorsAsync();

        /// <summary>
        /// Service to Get a coordinator by an group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>One Coordinator by the groupId</returns>
        Task<Coordinator?> GetCoordinatorByGroupIdAsync(string groupId);

        Task SaveEntity(Coordinator entity);
    }
}
