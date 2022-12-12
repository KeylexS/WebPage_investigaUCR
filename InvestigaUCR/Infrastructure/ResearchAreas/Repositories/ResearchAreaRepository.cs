using Domain.ResearchProjects.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchAreas.Repositories;
using Infrastructure.ResearchAreas.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ResearchAreas.Repositories
{
    /// <summary>
    /// Class <c>ResearchAreaRepository</c> Implements all the method from the IResearchAreaRepository interface.
    /// </summary>
    internal class ResearchAreaRepository : IResearchAreasRepository
    {
        protected readonly GeneralDbContext _dbContext;
        /// <summary>
        /// ResearchAreaRepository class parameterized constructor.
        /// </summary>
        /// <param name="dbContext">The new database context to use, specifically a ResearchAreasDbContext</param>
        public ResearchAreaRepository(GeneralDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Method <c>GetAllAsync</c> Get all the Areas in the database.
        /// </summary>
        /// <returns>An IEnumerable<ResearchArea></returns>
        public async Task<IEnumerable<ResearchArea>> GetAllAsync()
        {
            return await _dbContext.ResearchArea.Include(p => p.Projects).Include(g => g.ResearchGroup).ToListAsync();
        }
        /// <summary>
        /// Method <c>GetByIdAsync</c> Get a Area from the database with a matching Id.
        /// </summary>
        /// <param name="id">The Id of the Area to search</param>
        /// <returns>An instance of Area</returns>
        public async Task<ResearchArea?> GetByIdAsync(string id)
        {
            return await _dbContext.ResearchArea.FindAsync(id);
        }
    }
}
