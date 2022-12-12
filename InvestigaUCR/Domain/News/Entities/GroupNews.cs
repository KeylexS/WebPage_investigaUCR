using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.DTOs;
using LanguageExt;
using LanguageExt.ClassInstances;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>This entity represents a single news of a research group</summary>
namespace Domain.News.Entities
{
    public class GroupNews
    {
        [Key]
        public String Id { get; }
        public String? Title { get; set; }
        public String? Description { get; set; }
        public String? Author { get; }
        public Nullable<DateTime> PublicationDate { get; }
        public byte[]? Image { get; set; }
        public Group? Group { get; private set; }

        //*public ResearchGroupId GroupId { get; set; }//CQL

        /// <summary>Constructor with parameters of class News</summary>
        /// <param name="id">Identification of the new in base of research group that published it</param>
        /// <param name="title">Title news name</param>
        /// <param name="description">News description in page</param>
        /// <param name="author">Who creates the news</param>
        /// <param name="publicationDate">Publication date of the news</param>
        /// <param name="image">Image to set in news page</param>
        public GroupNews(String id, String? title, String? description, String? author, DateTime? publicationDate, Group? group, byte[]? img)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            PublicationDate = publicationDate;
            Group = group;
            Image = img;
        }

        /// <summary>Void constructor of class News</summary>
        public GroupNews()
        {
            Id = null!;
            Title = null!;
            Description = null!;
            Image = null!;
            Author = null!;
            PublicationDate = null!;
            Group = null!;
        }
    }
}
