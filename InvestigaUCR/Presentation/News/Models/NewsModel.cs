using Domain.News.Entities;
using Domain.ResearchGroups.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.News.Models
{
    public class NewsModel
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Group? Group { get; set; }
        public byte[]? Image { get; set; }
    }
}
