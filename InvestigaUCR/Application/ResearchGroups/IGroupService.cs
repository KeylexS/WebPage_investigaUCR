using Domain.ResearchAreas.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using Domain.Shared.Charts.Entities;
using Domain.People.Entities;
using Domain.Theses.Entities;

//User story: SD-RG-1.5 && TT: PIIB22II02-284 Make group's services
namespace Application.ResearchGroups
{
    /// <summary>
    /// Class <c>IGroupService</c> Interface that defines the group services to implement.
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Method <c>GetGroupAsync</c> Get all the groups from the database in a collection of GroupDTO.
        /// </summary>
        /// <returns>An IEnumerable<GroupDTO></returns>
        Task<IEnumerable<GroupDTO>> GetGroupAsync();

        Task<BarChart> GetResearchGroupPublicationsChartAsynca(int minYear, int maxYear); 

        //User story SD-RG-1.3 & TT: PIIB22II02-540 Add service "GetGroupByID"
        /// <summary>
        /// Method <c>GetGroupByIdAsync</c> Get the group from the database with a matching Id.
        /// </summary>
        /// <param name="id">The id of the group to search</param>
        /// <returns></returns>
        Task<Group?> GetGroupByIdAsync(String id);

        /// <summary>
        /// Method <c>SaveGroupImage</c> Put the new image into the group entity and then saves the entity in the database.
        /// </summary>
        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="img">The new image to save</param>
        /// <returns></returns>
        /// 
        Task SaveGroupImage(Group group, byte[]? img);

        /// <summary>
        /// Method <c>SaveGroupName</c> Put the new name into the group entity and then saves the entity in the database.
        /// </summary>
        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="name">The new name to save</param>
        /// <returns></returns>
        Task SaveGroupName(Group group, ResearchGroupName name);

        /// <summary>
        /// Method <c>SaveGroupDescription</c> Put the new description into the group entity and then saves the entity in the database.
        /// </summary>
        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="text">The new description to save</param>
        /// <returns></returns>
        Task SaveGroupDescription(Group group, ResearchGroupDescription text);

        /// <summary>
        /// Method <c>AddNewGroup</c> Add new group to the database.
        /// </summary>
        /// <param name="group">The new group instance</param>
        /// <returns></returns>
        Task AddGroup(Group id);

        /// <summary>
        /// Method <c>Detach group</c> Detaches an entity from the dbset
        /// </summary>
        /// <param name="group">The group instance to detach</param>
        void DetachGroup(Group group);

        /// <summary>
        /// Method <c>Detach group</c> Detaches an entity from the dbset
        /// </summary>
        /// <param name="group">The group instance to detach</param>
        void DetachGroupDTO(GroupDTO group);

        Task<Group?> GetByIdAsyncSingle(string id);

        /// <param name="group">The instance of the group to change/save</param>
        /// <param name="project">The new project to be added</param>
        /// <returns></returns>
        Task AddProjectsToGroup(Group group, List<ResearchProject> selectedProjects);

        Task<IEnumerable<ResearchProject>> GetAllProjectsAsync();
        Task AddPublicationToGroup(Publication publication, Group group);

        Task<IEnumerable<Publication>> GetAllPublicationsAsync();

        //US: PIIB22II02-891 SD-RG-2.17 Link research group with ResearchAreas && TT: PIIB22II02-893 Add interface and implementation of the service on application layer
        Task AddAreaToGroup(Group group, List<ResearchArea> selectedAreas);

        Task RemoveAreaofGroup(Group group,ResearchArea area);

        Task RemoveProjectsofGroup(Group group, List<ResearchProject> selectedProjects);

        Task<IEnumerable<ResearchArea>> GetAllAreasAsync();
        /// <summary>
        /// Method <c>DeleteGroup()</c> Delete the grouP
        /// </summary>
        /// <param name="group">The instance of the group to delete/save</param>
        /// <returns></returns>
        Task DeleteResearchGroup(Group group);

        
        /// <summary>
        /// Method <c>ChangeCoordinator</c> Change the coordinator of a research group and then update the group.
        /// </summary>
        /// <param name="group">Instance of the group to modify</param>
        /// <param name="person">Instance of the coordinator</param>
        /// <returns></returns>
        Task ChangeCoordinator(Group group, Person? person);        

        /// <summary>
        /// Method <c>AddResearchers</c> Adds a list of researchers to a research group.
        /// </summary>
        /// <param name="group">Instance of the group to modify</param>
        /// <param name="people">List of researchers to add</param>
        /// <returns></returns>
        Task AddResearchers(Group group, List<Person> people);

        /// <summary>
        /// Method <c>RemoveResearchers</c> Remove a list of researchers from a research group.
        /// </summary>
        /// <param name="group">Instance of the group to modify</param>
        /// <param name="people">List of researchers to remove</param>
        /// <returns></returns>
        Task RemoveResearchers(Group group, List<Person> people);

        /// <summary>
        /// Method <c>AddPublications</c> Adds a list of publications to a research group.
        /// </summary>
        /// <param name="group">Instance of the group to modify</param>
        /// <param name="publication">List of publications to add</param>
        /// <returns></returns>
        Task AddPublications(Group group, List<Publication> publication);

        /// <summary>
        /// Method <c>RemovePublications</c> Remove a list of publications from a research group.
        /// </summary>
        /// <param name="group">Instance of the group to modify</param>
        /// <param name="publications">List of publications to remove</param>
        /// <returns></returns>
        Task RemovePublications(Group group, List<Publication> publications);

        /// <summary>
        /// Method <c>AddTheses</c> Adds a list of theses to a research group.
        /// </summary>
        /// <param name="group">Instance of the group to modify</param>
        /// <param name="theses">List of theses to add</param>
        /// <returns></returns>
        Task AddTheses(Group group, List<Thesis> theses);

        /// <summary>
        /// Method <c>RemoveTheses</c> Remove a list of theses from a research group.
        /// </summary>
        /// <param name="group">Instance of the group to modify</param>
        /// <param name="theses">List of theses to remove</param>
        /// <returns></returns>
        Task RemoveTheses(Group group, List<Thesis> theses);

        Task<IEnumerable<Thesis>>GetAllThesesAsync();
    }
}
