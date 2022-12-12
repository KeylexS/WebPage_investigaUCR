using Domain.Core.Helpers;
using Domain.Core.Repositories;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.Repositories;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using Domain.Theses.Entities;
using LanguageExt;
using LanguageExt.Pipes;
using Microsoft.EntityFrameworkCore;


//User story:SD-RG-1.5 TT:PIIB22II02-285 Make the repository interface and implementation
namespace Infrastructure.ResearchGroups.Repositories
{
    /// <summary>
    /// Class <c>GroupRepository</c> Implements all the method from the IGroupRepository interface.
    /// </summary>
    internal class GroupRepository : IGroupRepository
    {
        private readonly GeneralDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        /// <summary>
        /// GroupRepository class parameterized constructor.
        /// </summary>
        /// <param name="unitOfWork">The new database context to use, specifically a GroupDbContext</param>
        public GroupRepository(GeneralDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
        /// Method <c>GetAllAsync</c> Get all the groups in the database in a collection of GroupDTOs.
        /// </summary>
        /// <returns>An IEnumerable<GroupDTO></returns>
        public async Task<IEnumerable<GroupDTO>> GetAllAsync()
        {
            //US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-572 Add image on Infrastructure implementation
            return await _dbContext.Groups.Select(t => new GroupDTO(t.Id, t.Name, t.Description, t.Image)).ToListAsync();
        }

        //User story SD-RG-1.3 & TT: PIIB22II02-540 Add service "GetGroupByID"
        /// <summary>
        /// Method <c>GetByIdAsync</c> Get a group from the database with a matching Id.
        /// </summary>
        /// <param name="id">The Id of the group to search</param>
        /// <returns>An instance of Group</returns>
        public async Task<Group?> GetByIdAsync(string id)
        {
            return await _dbContext.Groups
                //US: PIIB22II02-496 SD - RG - 1.10 Show group's research area && TT: PIIB22II02-646 Add the research areas on GroupRepository
                .Include(x => x.ResearchArea)
                //US: PIIB22II02-500 SD-RG-3.5 Show a preview of the research project on the research group page && TT: PIIB22II02-728 Add ResearchProjects to instance to GroupRepository
                .Include(r => r.ResearchProjects)
                //US: PIIB22II02-504 SD-RG-3.6 Show a preview of the publications on the research group page TT:PIIB22II02 - Add the mapping of publications in the groupmap
                .Include(p => p.Publications)
                .Include(r => r.ResearchProjects).ThenInclude(a => a.ResearchAreas)
                .Include(t => t.Thesis)
                .Include(c => c.Coordinator)
                .Include(r => r.Person)
                .AsAsyncEnumerable().FirstOrDefaultAsync(t => t.Id.ToString() == id);
        }


        public async Task<Group?> GetByIdAsyncSingle(string id)
        {
            var Id = ResearchGroupId.TryCreate(id).Success();
            return await _dbContext.Groups.FindAsync(Id);
        }

        /// <summary>
        /// Method <c>SaveAsync</c> Saves the group instance into the database or updates the information of an existing row.
        /// </summary>
        /// <param name="group">The group instance to save</param>
        /// <returns></returns>
        public async Task SaveAsync(Group group)
        {
            _dbContext.Update(group);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method <c>AddNewGroup</c> Add new group to the database.
        /// </summary>
        /// <param name="group">The new group instance</param>
        /// <returns></returns>
        public async Task AddNewGroup(Group group)
        {
            _dbContext.Add(group);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<ResearchArea>> GetAllAreasAsync()
        {
            return await _dbContext.ResearchArea.ToListAsync();
        }

        public void DetachGroup(Group group)
        {
            _dbContext.Entry(group).State = EntityState.Detached;
        }
        public void DetachGroupDTO(GroupDTO groupDTO)
        {
            Group? group = _dbContext.Groups.Where(g => g.Id == groupDTO.Id).FirstOrDefault();
            _dbContext.Entry(group!).State = EntityState.Detached;
        }

        public async Task<IEnumerable<ResearchProject>> GetAllProjectsAsync()
        {
            return await _dbContext.ResearchProject.ToListAsync();
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
        {
            return await _dbContext.Publications.ToListAsync();
        }

        public async Task DeleteGroup(Group group)
        {
            _dbContext.Remove(group);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Group>> GetAllGroupWhitPublicationsAsync(int minYear,int maxYear)
        {
            _dbContext.ChangeTracker.Clear();
            return await _dbContext.Groups.Include(p => p.Publications.Where(p => p._Date.Year >= minYear).Where(p => p._Date.Year <= maxYear)).ToListAsync();
        }

        public async Task<IEnumerable<Thesis>> GetAllThesesAsync()
        {
            return await _dbContext.Thesis.ToListAsync();
        }
    }
}
