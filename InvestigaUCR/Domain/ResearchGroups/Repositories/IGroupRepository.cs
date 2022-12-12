using Domain.Core.Repositories;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using Domain.Theses.Entities;

//User story; SD-RG-1.5 & TT: PIIB22II02-285 Make the repository interface and implementation
namespace Domain.ResearchGroups.Repositories
{
    /// <summary>
    /// Interface <c>IGroupRepository</c> Interface of Group repository with all the methods to implement.
    /// </summary>
    public interface IGroupRepository : IRepository<Group>
    {
        /// <summary>
        /// Method <c>GetAllAsync</c> Get all the groups from the database in a collection of GroupDTOs.
        /// </summary>
        /// <returns>An IEnumerable<GroupDTO></returns>
        Task<IEnumerable<GroupDTO>> GetAllAsync();

        Task<IEnumerable<Group>> GetAllGroupWhitPublicationsAsync(int minYear, int maxYear);

        //User story SD-RG-1.3 & TT: PIIB22II02-540 Add service "GetGroupByID"
        /// <summary>
        /// Method <c>GetByIdAsync</c> Get the group from the database with the matching Id.
        /// </summary>
        /// <param name="id">The id of the group to search</param>
        /// <returns>An instance of Group</returns>
        Task<Group?> GetByIdAsync(String id);

        /// <summary>
        /// Method <c>AddNewGroup</c> Add new group to the database.
        /// </summary>
        /// <param name="group">The new group instance</param>
        /// <returns></returns>
        Task AddNewGroup(Group group);
        /// <summary>
        /// Method <c>SaveAsync</c> Save the group entity on the database.
        /// </summary>
        /// <param name="group">The group instance to save</param>
        /// <returns></returns>
        Task SaveAsync(Group group);

        Task<IEnumerable<ResearchArea>> GetAllAreasAsync();

        /// <summary>
        /// Method <c>Detach group</c> Detaches an entity from the dbset
        /// </summary>
        /// <param name="group">The group instance to detach</param>
        /// <returns></returns>
        void DetachGroup(Group group);

        /// <summary>
        /// Method <c>Detach group</c> Detaches an entity from the dbset
        /// </summary>
        /// <param name="group">The group instance to detach</param>
        void DetachGroupDTO(GroupDTO group);

        Task<Group?> GetByIdAsyncSingle(string id);
        Task<IEnumerable<ResearchProject>> GetAllProjectsAsync();

        Task<IEnumerable<Publication>> GetAllPublicationsAsync();

        /// <summary>
        /// Method <c>DeleteGroup</c> Delete the group from de data base.
        /// </summary>
        /// <param name="group">The group instance to delete</param>
        Task DeleteGroup(Group group);

        Task<IEnumerable<Thesis>>GetAllThesesAsync();
    }
}
