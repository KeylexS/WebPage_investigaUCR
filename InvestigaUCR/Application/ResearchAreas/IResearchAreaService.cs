using Domain.ResearchAreas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResearchAreas
{
    /// <summary>
    /// Class <c>IResearchAreasService</c> Interface that defines the Area services to implement.
    /// </summary>
    public interface IResearchAreasService
    {
        /// <summary>
        /// Method <c>GetResearchAreaAsync</c> Get all the Areas from the database.
        /// </summary>
        /// <returns>An IEnumerable<ResearchArea></returns>
        Task<IEnumerable<ResearchArea>> GetResearchAreaAsync();
        /// <summary>
        /// Method <c>GetResearchAreaByIdAsync</c> Get the Area from the database with a matching Id.
        /// </summary>
        /// <param name="id">The id of the Area to search</param>
        /// <returns>An instance of a Area entity</returns>
        Task<ResearchArea?> GetResearchAreaByIdAsync(string id);

    }
}
