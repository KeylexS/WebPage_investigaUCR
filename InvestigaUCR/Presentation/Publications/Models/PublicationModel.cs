using Domain.Publications.Entities;
using Domain.ResearchGroups.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Publications.Models
{
    public class PublicationModel
    {
        public String? Name { get; set; }
        public String? DOI { get; set; }
        public String? Type { get; set; }
        public String? Publisher_Name { get; set; }
        public String? Abstract { get; set; }
        public String? Reference { get; set; }
        public DateTime? Date { get; set; }
        public Group? Group { get; set; }

    }
}