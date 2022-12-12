using Domain.Core.Repositories;
using Domain.News.DTOs;
using Domain.News.Entities;
using Domain.News.Repositories;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchProjects.ValueObjects;
using LanguageExt;
using LanguageExt.Pipes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Helpers;

namespace Infrastructure.News.Repositories
{
    internal class NewsRepository : INewsRepository
    {
        private readonly GeneralDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;


        /// <summary>
        /// NewsRepository class parameterized constructor.
        /// </summary>
        /// <param name="unitOfWork">The new database context to use, specifically a NewsDbContext</param>
        public NewsRepository(GeneralDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
        /// Method <c>GetAllAsync</c> Get all the news in the database in a collection of NewsDTOs.
        /// </summary>
        /// <returns>An IEnumerable<NewsDTO></returns>
        public async Task<IEnumerable<NewsDTO>> GetAllAsync()
        {
            return await _dbContext.News.Select(n => new NewsDTO(n.Id, n.Title, n.Description, n.Author, n.PublicationDate, n.Group, n.Image)).ToListAsync();
        }

        /// <summary>
        /// Method <c>GetByIdAsync</c> Get a news from the database with a matching Id.
        /// </summary>
        /// <param name="id">The Id of the news to search</param>
        /// <returns>An instance of News</returns>
        public async Task<GroupNews?> GetByIdAsync(String? id)
        {
            //*return await _dbContext.News.Include(g => g.Group).FirstOrDefaultAsync(n => n.Id == id);
            //
            return await _dbContext.News.FirstOrDefaultAsync(n => n.Id == id);
        }

        /// <summary>
        /// Method <c>SaveAsync</c> Saves the news instance into the database or updates the information of an existing row.
        /// </summary>
        /// <param name="group">The news instance to save</param>
        /// <returns></returns> await _dbContext.SaveChangesAsync();
        public async Task SaveAsync(GroupNews news)
        {
            _dbContext.Update(news);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method <c>AddNewNews</c> Add new news item to the database.
        /// </summary>
        /// <param name="news">The new news instance.</param>
        /// <returns></returns>
        public async Task AddNewNews(GroupNews news)
        {
            _dbContext.Add(news);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}
