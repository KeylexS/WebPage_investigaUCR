using Domain.Publications.Entities;
using Domain.Theses.Entities;
using Infrastructure.Shared;
using Infrastructure.Theses.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Theses.Repositories
{
    internal class ThesesRepository : IThesesRepository
    {
        protected readonly GeneralDbContext _dbContext;

        public ThesesRepository(GeneralDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Thesis>> GetAllAsync()
        {
            return await _dbContext.Thesis.ToListAsync();
        }

        public async Task<Thesis?> GetByIdAsync(int Id)
        {
            return await _dbContext.Thesis.FindAsync(Id);
        }
    }
}
