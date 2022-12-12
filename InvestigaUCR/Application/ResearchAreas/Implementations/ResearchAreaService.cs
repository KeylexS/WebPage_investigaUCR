using Domain.ResearchAreas.Entities;
using Domain.ResearchAreas.Repositories;
using Application.ResearchAreas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResearchAreas.Implementations
{
    /// <summary>
    /// Class <c>ResearchAreasService</c> Implements all the methods defined on IResearchAreaService
    /// </summary>
    internal class ResearchAreasService : IResearchAreasService
    {
        private readonly IResearchAreasRepository _researchAreasRepository;

        /// <summary>
        /// ResearchAreasService class parameterized constructor. 
        /// </summary>
        /// <param name="researchProjectsRepository">An instance of the Area repository</param>
        public ResearchAreasService(IResearchAreasRepository researchProjectsRepository)
        {
            _researchAreasRepository = researchProjectsRepository;
        }

        /// <summary>
        /// Method <c>GetResearchAreaAsync</c> Get all the Areas from the database.
        /// </summary>
        /// <returns>An IEnumerable<ResearchArea></returns>
        public async Task<IEnumerable<ResearchArea>> GetResearchAreaAsync()
        {
            return await _researchAreasRepository.GetAllAsync();
        }

        /// <summary>
        /// Method <c>GetResearchAreaByIdAsync</c> Get the Area from the database with a matching Id.
        /// </summary>
        /// <param name="id">The id of the Area to search</param>
        /// <returns>An instance of a Area entity</returns>
        public async Task<ResearchArea?> GetResearchAreaByIdAsync(string id)
        {
            return await _researchAreasRepository.GetByIdAsync(id);
        }


    }
}
