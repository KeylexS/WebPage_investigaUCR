using Domain.Core.Repositories;
using Domain.News.DTOs;
using Domain.News.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.News.Repositories
{
    /// <summary>
    /// This is a interface class of GroupNews entity
    /// </summary>
    public interface INewsRepository
    {
        /// <summary>
        /// Method <c>GetAllAsync</c> Get all the news from the database in a collection of GroupDTOs.
        /// </summary>
        /// <returns>An IEnumerable<NewsDTO></returns>
        Task<IEnumerable<NewsDTO>> GetAllAsync();

        /// <summary>
        /// Method <c>GetByIdAsync</c> Save the group entity on the database.
        /// </summary>
        /// <param name="id">Id of the news searched</param>
        /// <returns>GroupNews = The news searched</returns>
        Task<GroupNews?> GetByIdAsync(String? id);
        
        /// <summary>
        /// Method <c>SaveAsync</c> Save the news entity on the database.
        /// </summary>
        /// <param name="news">The news instance to save</param>
        /// <returns></returns>-
        Task SaveAsync(GroupNews news);

        /// <summary>
        /// Method <c>AddNewNews</c> Add a new news item to the database.
        /// </summary>
        /// <param name="news">The new news instance.</param>
        /// <returns></returns>
        Task AddNewNews(GroupNews news);
    }
}
