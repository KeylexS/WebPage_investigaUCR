using Domain.People.DTOs;
using Domain.People.Entities;
using Domain.People.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PIIB22II02-370 MC-PL-1.8 Organize card of the researcher role in a research group Task: PIIB22II02-1084 Add service of researcher

namespace Application.People.Implementations
{
    public class ResearcherServices : IResearcherService
    {
        private readonly IResearcherRepository ResearcherRepository;

        public ResearcherServices(IResearcherRepository researcherRepository)
        {
            ResearcherRepository = researcherRepository;
        }

        /// <summary>
        /// Service to get the the list of all researchers
        /// </summary>
        /// <returns>The list of people</returns>
        public async Task<IEnumerable<ResearcherDto>> GetAllResearchersAsync()
        {
            return await ResearcherRepository.GetAllResearchersAsync();
        }

        /// <summary>
        /// Service to Get the lists of coordinator of a  group 
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>One Coordinator by the groupId</returns>
        public async Task<IEnumerable<ResearcherDto>> GetReseachersByGroupIdAsync(string groupId)
        {
            return await ResearcherRepository.GetResearchersByGroupIdAsync(groupId);
        }
    }
}
