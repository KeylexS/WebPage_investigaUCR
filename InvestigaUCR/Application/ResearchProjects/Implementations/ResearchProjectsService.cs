using Domain.ResearchProjects.Entities;
using Domain.People.Entities;
using Domain.ResearchProjects.Repositories;
using Application.Shared.StringManipulation;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Shared.StringManipulation.Implementations;
using Domain.ResearchGroups.Entities;
using System.Globalization;
using Domain.Publications.Entities;
using Domain.Theses.Entities;
using Domain.ResearchAreas.Entities;

namespace Application.ResearchProjects.Implementations
{
    /// <summary>
    /// Class <c>ResearchProjectsService</c> Implements all the methods defined on IResearchAreaService
    /// </summary>
    internal class ResearchProjectsService : IResearchProjectsService
    {
        private readonly IResearchProjectsRepository _researchProjectsRepository;

        /// <summary>
        /// ResearchAreasService class parameterized constructor. 
        /// </summary>
        /// <param name="researchProjectsRepository">An instance of the Research Project repository</param>
        public ResearchProjectsService(IResearchProjectsRepository researchProjectsRepository)
        {
            _researchProjectsRepository = researchProjectsRepository;
        }

        /// <summary>
        /// Method <c>GetResearchProjectsAsync</c> Returns a list with all research projects
        /// <returns>A IEnumerable<ResearchProject></returns>
        public async Task<IEnumerable<ResearchProject>> GetResearchProjectsAsync()
        {
            return await _researchProjectsRepository.GetAllAsync();
        }

        /// <summary>
        /// Method <c>GetResearchProjectByGroupIdAsync</c> Return the project with an id
        /// <returns>A Task<ResearchProject></returns>
        public async Task<ResearchProject?> GetResearchProjectByIdAsync(string? id)
        {
            return await _researchProjectsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsyncfromRP()
        {
            return await _researchProjectsRepository.GetAllPeopleAsyncfromRP();
        }

        /// <summary>
        /// Method <c>GetFilteredResearchProjects</c> Returns an enumerable with all projects that contain a search string
        /// </summary>
        /// <param name="searchText">The text to match</param>
        /// <param name="projects">The list of Project where search</param>
        /// <returns>An IEnumerable<ResearchProject></returns>
        public IEnumerable<ResearchProject> GetFilteredResearchProjects(string searchText, IEnumerable<ResearchProject> projects)
        {
            StringManipulationService stringManipulation = new StringManipulationService();
            return projects.ToList()
            .Where(project =>
                stringManipulation.standarizeText(project.Name.ToString().ToLower())
                .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                ||
                stringManipulation.standarizeText(project.getDescription()!.ToString().ToLower())
                .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                ||
                stringManipulation.standarizeText(project.Id!.ToString().ToLower())
                .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                ||
                project!.Start_date.ToString("d/MMMM/yyyy", CultureInfo.GetCultureInfo("es-ES"))
                .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                ||
                project!.End_date.ToString("d/MMMM/yyyy", CultureInfo.GetCultureInfo("es-ES"))
                .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                )
            .ToList();
        }

        public async Task SaveCollab(Collaborate collab)
        {
            await _researchProjectsRepository.SaveCollab(collab);
        }

        /// <summary>
        /// Method <c>AddResearchProject</c>  Adds a project
        /// </summary>
        /// <param name="project">The project that will be added</param>
        /// <param name="group">The group that the project will be associated to</param>
        /// <param name="mainResearcher">The mainResearcher of the project</param>
        public async Task AddResearchProject(ResearchProject project, Group group, Person mainResearcher, List<Publication> publications)
        {
            project.Group = group;
            project.MainResearcher = mainResearcher;
           
            if (publications != null)
            {
                project.Publications = publications;
            }
            
            await _researchProjectsRepository.SaveResearchProject(project);
        }

        /// <summary>
        /// Method <c>DeleteResearchProject</c>
        /// </summary>
        /// <param name="project"> Delete a research project from the database </param>
        public async Task DeleteResearchProject(ResearchProject project)
        {
            await _researchProjectsRepository.DeleteResearchProject(project);
        }

        /// <summary>
        /// Method <c>SaveProjectImage</c> Put the new image into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="img">The new image to save</param>
        /// <returns></returns>
        public async Task SaveProjectImage(ResearchProject project, byte[]? img)
        {
            project.Image = img;
            await _researchProjectsRepository.SaveAsync(project);
        }

        /// <summary>
        /// Method <c>SaveProjectName</c> Put the new name into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="name">The new name to save</param>
        /// <returns></returns>
        public async Task SaveProjectName(ResearchProject project, String name)
        {
            project.Name = name;
            await _researchProjectsRepository.SaveAsync(project);
        }

        /// <summary>
        /// Method <c>SaveProjectDescription</c> Put the new description into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="text">The new description to save</param>
        /// <returns></returns>
        public async Task SaveProjectDescription(ResearchProject project, String text)
        {
            project.Description = text;
            await _researchProjectsRepository.SaveAsync(project);
        }

        /// <summary>
        /// Method <c>SaveProjectDates</c> Add the new dates into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// /// <param name="StartDate">The new start date to save</param>
        /// /// <param name="EndDate">The new end date to save</param>
        /// <returns></returns>
        public async Task SaveProjectDates(ResearchProject project, DateTime StartDate, DateTime EndDate)
        {
            project.Start_date = StartDate;
            project.End_date = EndDate;
            await _researchProjectsRepository.SaveAsync(project);
        }

        public async Task AddPublicationAsync(ResearchProject researchProject, Publication publication)
        {
            researchProject.AddPublication(publication);
            await _researchProjectsRepository.GeneralSaveResearchProject(researchProject);
        }

        public async Task DeletePublicationAsync(ResearchProject researchProject, Publication publication)
        {
            researchProject.DeletePublication(publication);
            await _researchProjectsRepository.GeneralSaveResearchProject(researchProject);
        }

        /// <summary>
        /// Method. Adds a thesis to list of theses associated to a project and updates the project entity
        /// </summary>
        /// <param name="thesis">The thesis to be added</param>
        /// <param name="project">The project that will be updated</param>
        public async Task AddThesisToProject(Thesis thesis, ResearchProject project)
        {
            project.AddThesis(thesis);
            await _researchProjectsRepository.UpdateResearchProject(project);
        }
        /// <summary>
        /// Method <c>SaveProjectDates</c> Add the new dates into the project entity and then saves the entity in the database.
        /// </summary>
        /// <param name="project">The instance of the project to change/save</param>
        /// <param name="EndDate">The new end date to save</param>
        /// <returns></returns>
        public async Task SaveProjectStatus(ResearchProject project, DateTime EndDate)
        {
            project.End_date = EndDate;
            await _researchProjectsRepository.SaveAsync(project);
        }

        /// <summary>
        /// Method that remove a specific area of a project.
        /// </summary>
        /// /// <param name="project">The instance of the project to change/save</param>
        /// <param name="area">The instance of the area to remove</param>
        public async Task RemoveAreaofProject(ResearchProject project, ResearchArea area)
        {
            project.RemoveResearchArea(area);
            await _researchProjectsRepository.SaveAsync(project);
        }

        /// <summary>
        /// Method. Deletes a thesis from list of theses associated to a project and updates project entity
        /// </summary>
        /// <param name="thesis">The thesis to be deleted</param>
        /// <param name="project">The project that will be updated</param>
        public async Task DeleteThesisFromProject(Thesis thesis, ResearchProject project)
        {
            project.DeleteThesis(thesis);
            await _researchProjectsRepository.UpdateResearchProject(project);
        }
    }
}
