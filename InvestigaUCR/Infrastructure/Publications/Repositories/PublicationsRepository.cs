using System.Linq;
using Domain.People.Relations;
using Domain.Publications.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using Infrastructure.Publications.DbContexts;
using Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Publications.Repositories
{
    internal class PublicationsRepository : IPublicationsRepository
    {
        protected readonly GeneralDbContext _dbContext;

        public PublicationsRepository(GeneralDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // PIIB22II02-361 HT-PB-1.12 Order publications by date  / TT: PIIB22II02-1076 Order publications by date 
        public async Task<IEnumerable<Publication>> GetAllAsync()
        {
            return await _dbContext.Publications.OrderByDescending(p => p._Date).ToListAsync();
        }

        public async Task<Publication?> GetByDOIAsync(string DOI)
        {
            return await _dbContext.Publications.FindAsync(DOI);
        }
        public async Task SavePublication(Publication publication)
        {
            _dbContext.Add(publication);
            await _dbContext.SaveEntitiesAsync();
        }
        
		//PIIB22II02-897 HT-PB-3.9 Show related groups
		public async Task<IEnumerable<GroupDTO?>> GetGroupByDOI(string? DOI)
		{
            // The DOI's respective publication
            var publication = await GetByDOIAsync(DOI);
            IEnumerable<GroupDTO> group ;
            if (publication.Group != null)
            {
                group = await _dbContext.Groups
                    .Where(g => g.Id!.Equals(publication.Group.Id))
                    .Select(g => new GroupDTO(g.Id, g.Name, g.Description, g.Image))
                    .ToListAsync();
                return group;

            }

            // Return the list of groups
            return null!;
            
		}
        public async Task SaveAsync(Publication publication)
        {
            _dbContext.Update(publication);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePublication(Publication publication)
        {
            _dbContext.Remove(publication);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}
