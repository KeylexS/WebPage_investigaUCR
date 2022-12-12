using Domain.Core.Exceptions;
using Domain.ResearchAreas.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Repositories;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using Domain.Shared.Charts.Entities;
using Group = Domain.ResearchGroups.Entities.Group;
using Domain.People.Entities;
using Domain.Theses.Entities;

//User story: SD-RG-1.5 && TT: PIIB22II02-284 Make group's services
namespace Application.ResearchGroups.Implementations
{
    /// <summary>
    /// Class <c>GroupService</c> Implements all the methods defined on IGroupService
    /// </summary>
    internal class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        /// <summary>
        /// GroupService class parameterized constructor. 
        /// </summary>
        /// <param name="groupRepository">An instance of the group repository</param>
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        /// <summary>
        /// Method <c>GetGroupAsync</c> Get all the groups from the database in a collection of GroupDTO.
        /// </summary>
        /// <returns>An IEnumerable<GroupDTO></returns>
        public async Task<IEnumerable<GroupDTO>> GetGroupAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        /// <summary>
        /// Method <c>GetGroupByIdAsync</c> Get the group from the database with a matching Id.
        /// </summary>
        /// <param name="id">The id of the group to search</param>
        /// <returns>An instance of a Group entity</returns>
        public async Task<Group?> GetGroupByIdAsync(String id)
        {
            return await _groupRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Method <c>SaveGroupImage</c> Put the new image into the group entity and then saves the entity in the database.
        /// </summary>
        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="img">The new image to save</param>
        /// <returns></returns>
        public async Task SaveGroupImage(Group group, byte[]? img) {
            group.Image = img;
            await _groupRepository.SaveAsync(group);
        }

        //US: PIIB22II02-891 SD-RG-2.17 Link research group with ResearchAreas && TT: PIIB22II02-893 Add interface and implementation of the service on application layer
        public async Task AddAreaToGroup(Group group, List<ResearchArea> selectedAreas) 
        {
            group.addResearchAreatosGroup(group, selectedAreas);
            await _groupRepository.SaveAsync(group);
        }

        public async Task<IEnumerable<ResearchArea>> GetAllAreasAsync()
        {
            return await _groupRepository.GetAllAreasAsync();
        }

        /// <summary>
        /// Method <c>SaveGroupName</c> Put the new name into the group entity and then saves the entity in the database.
        /// </summary>
        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="name">The new name to save</param>
        /// <returns></returns>
        public async Task SaveGroupName(Group group, ResearchGroupName name)
        {
            group.Name = name;
            await _groupRepository.SaveAsync(group);
        }

        /// <summary>
        /// Method <c>SaveGroupDescription</c> Put the new description into the group entity and then saves the entity in the database.
        /// </summary>
        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="text">The new description to save</param>
        /// <returns></returns>
        public async Task SaveGroupDescription(Group group, ResearchGroupDescription text)
        {
            group.Description = text;
            await _groupRepository.SaveAsync(group);
        }

        /// <summary>
        /// Method <c>AddNewGroup</c> Add new group to the database.
        /// </summary>
        /// <param name="group">The new group instance</param>
        /// <returns></returns>
        public async Task AddGroup(Group group)
        {            
            Group? aux = await _groupRepository.GetByIdAsync(group.Id.Value);
            if(aux == null)
            {
                await _groupRepository.AddNewGroup(group);
            } 
            else
            {
                throw new DomainException("El identificador asignado ya existe, por favor elija uno diferente.");
            }
            
        }

        /// <summary>
        /// Method <c>SaveGroupImage</c> Adds a project to a group and calls repository to save them in the database.
        /// </summary>
        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="project">The new project to be added</param>
        /// <returns></returns>
        public async Task AddProjectsToGroup(Group group, List<ResearchProject> projects)
        {
            group.addResearchProjectsToGroup(projects);
            await _groupRepository.SaveAsync(group);
        }

        public async Task<IEnumerable<ResearchProject>> GetAllProjectsAsync()
        {
            return await _groupRepository.GetAllProjectsAsync();
        }

        public void DetachGroup(Group group)
        {
            _groupRepository.DetachGroup(group);
        }

        public void DetachGroupDTO(GroupDTO group)
        {
            _groupRepository.DetachGroupDTO(group);
        }

        public Task<Group?> GetByIdAsyncSingle(string id)
        {
            return _groupRepository.GetByIdAsyncSingle(id);
        }

        public async Task AddPublicationToGroup(Publication publication, Group group)
         {
            group._publications.Add(publication);
            publication.Group = group;
            await _groupRepository.SaveAsync(group);
        }

        public async Task RemoveAreaofGroup(Group group, ResearchArea area)
        {
            group.RemoveResearchArea(area);
            await _groupRepository.SaveAsync(group);
        }

        public async Task RemoveProjectsofGroup(Group group, List<ResearchProject> selectedProjects)
        {
            group.RemoveResearchProjects(group, selectedProjects);
            await _groupRepository.SaveAsync(group);
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
        {
            return await _groupRepository.GetAllPublicationsAsync();
        }

        public async Task DeleteResearchGroup(Group group)
        {
            await _groupRepository.DeleteGroup(group);
        }

        public async Task ChangeCoordinator(Group group, Person? person)
        {
            group.Coordinator = person;
            await _groupRepository.SaveAsync(group);
        }


        public async Task<BarChart> GetResearchGroupPublicationsChartAsynca(int minYear, int maxYear)
        {
            var chart = new BarChart();
            IEnumerable<Group> _groups;
            _groups = await _groupRepository.GetAllGroupWhitPublicationsAsync(minYear,maxYear);
            string ChartType = "Bar";
            List<string> labels = _groups.Select(g => g.Id.ToString()).ToList();

            List<double> Values = new List<double>();
            foreach (var group in _groups)
            {
                Values.Add(group.Publications.Count());
            }
            chart = new BarChart(ChartType, labels, Values);
            return chart;
        }
        public async Task AddResearchers(Group group, List<Person> people)
        {
            group.addResearchersToGroup(people);
            await _groupRepository.SaveAsync(group);
        }

        public async Task RemoveResearchers(Group group, List<Person> people)
        {
            group.removeResearchers(people);
            await _groupRepository.SaveAsync(group);
        }

        public async Task AddPublications(Group group, List<Publication> publication)
        {
            group.addPublicationsToGroup(publication);
            await _groupRepository.SaveAsync(group);
        }
        public async Task RemovePublications(Group group, List<Publication> publication)
        {
            group.removePublications(publication);
            await _groupRepository.SaveAsync(group);
        }
        public async Task AddTheses(Group group, List<Thesis> theses)
        {
            group.addThesesToGroup(theses);
            await _groupRepository.SaveAsync(group);
        }
        public async Task RemoveTheses(Group group, List<Thesis> theses)
        {
            group.removeTheses(theses);
            await _groupRepository.SaveAsync(group);
        }

        public async Task<IEnumerable<Thesis>> GetAllThesesAsync()
        {
            return await _groupRepository.GetAllThesesAsync();
        }
    }
}
