/*
    US ID: PIIB22II02-186
    US name: KS-RP-1.2 Card Display
    Technical Task Resolved: PIIB22II02-307 Implement Research Project Repository in Domain
*/
using Domain.People.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResearchProjects.Repositories
{
    /// <summary>
    /// Interface <c>IResearchProjectsRepository</c> Interface of Research Project repository with all the methods to implement.
    /// </summary>
    public interface IResearchProjectsRepository
    {
        /// <summary>
        /// Method <c>GetByIdAsync</c> Get the Research Project from the database with the matching Id.
        /// </summary>
        /// <param name="id">The id of the Research Project to search</param>
        /// <returns>An instance of Research Project</returns>
        Task<ResearchProject?> GetByIdAsync(string? id);

        /// <summary>
        /// Method <c>GetAllAsync</c> Get all the Research Projects from the database.
        /// </summary>
        /// <returns>An IEnumerable<ResearchProject></returns>
        Task<IEnumerable<ResearchProject>> GetAllAsync();

        Task<IEnumerable<Person>> GetAllPeopleAsyncfromRP();

        Task SaveCollab(Collaborate collab);

        /// <summary>
        /// Method <c>AddResearchProject</c> Adds a research project to the database
        /// </summary>
        /// <param name="project">The project instance to add </param>
        Task SaveResearchProject(ResearchProject project);

        /// <summary>
        /// Method <c>DeleteResearchProject</c> Delete a research project from the database.
        /// </summary>
        /// <param name="project">The project instance to add </param>
        Task DeleteResearchProject(ResearchProject project);
        Task GeneralSaveResearchProject(ResearchProject project);

        /// <summary>
        /// Method <c>SaveAsync</c> Save the project entity on the database.
        /// </summary>
        /// <param name="project">The project instance to save</param>
        /// <returns></returns>
        Task SaveAsync(ResearchProject project);

        Task UpdateResearchProject(ResearchProject project);
    }
}