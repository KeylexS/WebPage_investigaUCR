using Domain.Core.ValueObjects;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.News.DTOs
{
    /// <summary>This class creates a single news of a research group</summary>
    public class NewsDTO
    {
        public String Id { get; }
        public String? Title { get; }
        public String? Description { get; }
        public String? Author { get; }
        public Nullable<DateTime> PublicationDate { get; }
        public Group? Group { get; }
        public byte[]? Image { get; set; }

        /// <summary>Constructor with parameters of class NewsDTO</summary>
        /// <param name="id">Identification of the new in base of research group that published it</param>
        /// <param name="title">Title news name</param>
        /// <param name="description">News description in page</param>
        /// <param name="imgs">List of images to set in news page</param>
        /// <param name="author">Who creates the news</param>
        /// <param name="publicationDate">Publication date of the news</param>
        public NewsDTO(string id, string? title, string? description, string? author, DateTime? publicationDate, Group? group, byte[]? img)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            PublicationDate = publicationDate;
            Group = group;
            Image = img;
        }
    }
}
