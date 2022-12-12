using Domain.Core.Exceptions;
using Domain.News.DTOs;
using Domain.News.Entities;
using Domain.News.Repositories;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.Repositories;
using Domain.ResearchGroups.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.News.Implementations
{
    internal class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        /// <summary>
        /// NewsService class parameterized constructor. 
        /// </summary>
        /// <param name="newsRepository">An instance of the news repository</param>
        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        /// <summary>
        /// Method <c>GetNewsAsync</c> Get all the news from the database in a collection of NewsDTO.
        /// </summary>
        /// <returns>An IEnumerable<NewsDTO></returns>
        public async Task<IEnumerable<NewsDTO>> GetNewsAsync()
        {
            return await _newsRepository.GetAllAsync();
        }

        /// <summary>
        /// Method <c>GetGroupByIdAsync</c> Get the news from the database with a matching Id.
        /// </summary>
        /// <param name="id">The id of the news to search</param>
        /// <returns>An instance of a News entity</returns>
        public async Task<GroupNews?> GetNewsByIdAsync(String? id)
        {
            return await _newsRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Method <c>SaveNewsImage</c> Put the new image into the news entity and then saves the entity in the database.
        /// </summary>
        /// <param name="news">The instance of the group to change/save</param>
        /// <param name="img">The new image to save</param>
        /// <returns></returns>
        
        public async Task SaveNewsImage(GroupNews news, byte[]? img)
        {
            news.Image = img;
            await _newsRepository.SaveAsync(news);
        }

        /// <summary>
        /// Method <c>GetDay</c> Conversion of the Day from Datetime to String.
        /// </summary>
        /// <param name="news">The news to search to be converted</param>
        /// <returns>string of the data converted</returns>
        public string GetDay(NewsDTO news)
        {
            if (news.PublicationDate != null)
            {
                return news.PublicationDate.Value.ToString("dd").ToUpper();
            }
            else
            {
                return "01";
            }
        }

        /// <summary>
        /// Method <c>GetMonth</c> Conversion of the Month from Datetime to String.
        /// </summary>
        /// <param name="news">The news to search to be converted</param>
        /// <returns>string of the data converted</returns>
        public string GetMonth(NewsDTO news)
        {
            if (news.PublicationDate != null)
            {
                return news.PublicationDate.Value.ToString("MMM").ToUpper();
            }
            else
            {
                return "ENE";
            }
        }

        /// <summary>
        /// Method <c>GetYear</c> Conversion of the Year from Datetime to String.
        /// </summary>
        /// <param name="news">The news to search to be converted</param>
        /// <returns>string of the data converted</returns>
        public string GetYear(NewsDTO news)
        {
            if (news.PublicationDate != null)
            {
                return news.PublicationDate.Value.ToString("yyyy").ToUpper();
            }
            else
            {
                return "1970";
            }
        }

        /// <summary>
        /// Method <c>AddNews</c> Add new news item to the database.
        /// </summary>
        /// <param name="news">The new news item instance.</param>
        /// <returns></returns>
        public async Task AddNews(GroupNews news)
        {
            await _newsRepository.AddNewNews(news);
        }

        /// <summary>
        /// Method <c>SaveNewsName</c> Put the new name into the news entity and then saves the entity in the database.
        /// </summary>
        /// <param name="news">The instance of the news to change/save</param>
        /// <param name="title">The new name to save</param>
        /// <returns></returns>
        public async Task SaveNewsTitle(GroupNews news, string? title)
        {
            if(title != null)
            {
                news.Title = title;
            }
            await _newsRepository.SaveAsync(news);
        }

        /// <summary>
        /// Method <c>SaveNewsDescription</c> Put the new description into the news entity and then saves the entity in the database.
        /// </summary>
        /// <param name="news">The instance of the news to change/save</param>
        /// <param name="description">The new description to save</param>
        /// <returns></returns>
        public async Task SaveNewsDescription(GroupNews news, string? description)
        {
            if(description != null)
            {
                news.Description = description;
            }
            await _newsRepository.SaveAsync(news);
        }
    }
}
