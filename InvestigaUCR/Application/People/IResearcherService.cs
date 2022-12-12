using Domain.People.DTOs;
using Domain.People.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.People
{
    // PIIB22II02-370 MC-PL-1.8 Organize card of the researcher role in a research group Task: PIIB22II02-1084 Add service of researcher
    public interface IResearcherService
    {
        /// <summary>
        /// Service to get the the list of all researcher
        /// </summary>
        /// <returns>The list of people</returns>
        Task<IEnumerable<ResearcherDto>> GetAllResearchersAsync();

        /// <summary>
        /// Service to Get a a list of researchers by an group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>One Coordinator by the groupId</returns>
        Task<IEnumerable<ResearcherDto>> GetReseachersByGroupIdAsync(string groupId);
    }
}
