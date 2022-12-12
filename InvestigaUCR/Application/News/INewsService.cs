using Domain.News.DTOs;
using Domain.News.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.News
{
    public interface INewsService
    {
        /// <summary>
        /// Method <c>GetGroupAsync</c> Get all the news from the database in a collection of NewsDTO.
        /// </summary>
        /// <returns>An IEnumerable<NewsDTO> </returns>
        Task<IEnumerable<NewsDTO>> GetNewsAsync();

        /// <summary>
        /// Method <c>GetNewsByIdAsync</c> Get the news from the database with a matching Id.
        /// </summary>
        /// <param name="id">The id of the news to search</param>
        /// <returns></returns>
        Task<GroupNews?> GetNewsByIdAsync(String? id);

        /// <summary>
        /// Method <c>SaveGroupImage</c> Put the new image into the news entity and then saves the entity in the database.
        /// </summary>
        /// <param name="news">The instance of the news to change/save</param>
        /// <param name="img">The new image to save</param>
        /// <returns></returns>
        Task SaveNewsImage(GroupNews news, byte[]? img);

        /// <summary>
        /// Method <c>GetDay</c> Conversion of the Day from Datetime to String.
        /// </summary>
        /// <param name="news">The news to search to be converted</param>
        /// <returns>string of the data converted</returns>
        string GetDay(NewsDTO news);

        /// <summary>
        /// Method <c>GetMonth</c> Conversion of the Month from Datetime to String.
        /// </summary>
        /// <param name="news">The news to search to be converted</param>
        /// <returns>string of the data converted</returns>
        string GetMonth(NewsDTO news);

        /// <summary>
        /// Method <c>GetYear</c> Conversion of the Year from Datetime to String.
        /// </summary>
        /// <param name="news">The news to search to be converted</param>
        /// <returns>string of the data converted</returns>
        string GetYear(NewsDTO news);

        /// <summary>
        /// Method <c>AddNews</c> Add new news item to the database.
        /// </summary>
        /// <param name="news">The new news item instance.</param>
        /// <returns></returns>
        Task AddNews(GroupNews news);

        /// <summary>
        /// Method <c>SaveNewsName</c> Put the new name into the news entity and then saves the entity in the database.
        /// </summary>
        /// <param name="news">The instance of the group to change/save</param>
        /// <param name="title">The new name to save</param>
        /// <returns></returns>
        Task SaveNewsTitle(GroupNews news, string? title);

        /// <summary>
        /// Method <c>SaveNewsDescription</c> Put the new description into the news entity and then saves the entity in the database.
        /// </summary>
        /// <param name="news">The instance of the news to change/save</param>
        /// <param name="description">The new description to save</param>
        /// <returns></returns>
        Task SaveNewsDescription(GroupNews news, string? description);
    }
}
