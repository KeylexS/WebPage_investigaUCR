using Domain.People.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using Domain.Publications.Entities;
using Domain.ResearchProjects.Repositories;
using Domain.Theses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ResearchAreas.Entities;

namespace Application.ResearchProjects
{
    /// <summary>
    /// Class <c>IResearchProjectsService</c> Interface that defines the Project services to implement.
    /// </summary>
    public interface IResearchProjectsService
    {
        /// <summary>
        /// Method <c>GetAllAsync</c> Get all the Research Projects from the database.
        /// </summary>
        /// <returns>An IEnumerable<ResearchProject></returns>
        Task<IEnumerable<ResearchProject>> GetResearchProjectsAsync();
        
        /// <summary>
        /// Method <c>GetByIdAsync</c> Get the Research Project from the database with the matching Id.
        /// </summary>
        /// <param name="id">The id of the Research Project to search</param>
        /// <returns>An instance of Research Project</returns>
        Task<ResearchProject?> GetResearchProjectByIdAsync(string? id);

        Task<IEnumerable<Person>> GetAllPeopleAsyncfromRP();

        /// <summary>
        /// Method <c>GetFilteredResearchProjects</c> Returns an enumerable with all projects that contain a search string
        /// </summary>
        /// <param name="searchText">The text to match</param>
        /// <param name="projects">The list of Project where search</param>
        /// <returns>An IEnumerable<ResearchProject></returns>
        IEnumerable<ResearchProject> GetFilteredResearchProjects(string text, IEnumerable<ResearchProject> projects);

        /// <summary>
        /// Method <c>AddResearchProject</c>  Adds a project
        /// </summary>
        /// <param name="project">The project instance to add </param>
        /// <param name="group">The group instance to create project</param>
        /// <param name="mainResearcher">The person instance to create project</param>
        Task AddResearchProject(ResearchProject project, Group group, Person mainResearcher, List<Publication> publications);


        /// <summary>
        /// Method <c>DeleteResearchProject</c>
        /// </summary>
        /// <param name="project"> Delete a research project from the database </param>
        Task DeleteResearchProject(ResearchProject project);

        /// <summary>
        /// Method <c>SaveGroupImage</c> Put the new image into the group entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the group to change/save</param>
        /// <param name="img">The new image to save</param>
        /// <returns></returns>
        Task SaveProjectImage(ResearchProject project, byte[]? img);

        /// <summary>
        /// Method <c>SaveGroupName</c> Put the new name into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="name">The new name to save</param>
        /// <returns></returns>
        Task SaveProjectName(ResearchProject project, String name);

        /// <summary>
        /// Method <c>SaveGroupDescription</c> Put the new description into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="text">The new description to save</param>
        /// <returns></returns>
        Task SaveProjectDescription(ResearchProject project, String text);

        /// <summary>
        /// Method <c>SaveProjectDates</c> Add the new date into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="StartDate">The new start date to save</param>
        /// <param name="EndDate">The new end date to save</param>
        /// <returns></returns>
        Task SaveProjectDates(ResearchProject project, DateTime StartDate, DateTime EmdDate);

        Task SaveCollab(Collaborate collab);

        Task AddPublicationAsync(ResearchProject researchProject, Publication publication);
        Task DeletePublicationAsync(ResearchProject researchProject, Publication publication);

        /// <summary>
        /// Method. Adds a thesis to list of theses associated to a project and updates the project entity
        /// </summary>
        /// <param name="thesis">The thesis to be added</param>
        /// <param name="project">The project that will be updated</param>
        Task AddThesisToProject(Thesis thesis, ResearchProject project);
        /// <summary>
        /// Method <c>SaveProjectDates</c> Add the new date into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="EndDate">The new end date to save</param>
        /// <returns></returns>
        Task SaveProjectStatus(ResearchProject project, DateTime EndDate);

        /// <summary>
        /// Method that remove a specific area of a project.
        /// </summary>
        /// /// <param name="project">The instance of the project to change/save</param>
        /// <param name="area">The instance of the area to remove</param>
        Task RemoveAreaofProject(ResearchProject project, ResearchArea area);

        /// <summary>
        /// Method. Deletes a thesis from list of theses associated to a project and updates project entity
        /// </summary>
        /// <param name="thesis">The thesis to be deleted</param>
        /// <param name="project">The project that will be updated</param>
        Task DeleteThesisFromProject(Thesis thesis, ResearchProject project);
    }
}
