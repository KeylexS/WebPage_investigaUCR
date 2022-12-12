using Domain.People.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ResearchProjects.Models
{
    public class ResearchProjectModel
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String? Description { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
        public byte[]? Image { get; set; }
        public Person? MainResearcher { get; set; }
        public Group Group { get; set; }
        public ResearchProjectModel()
        {
            Id = null!;
            Name = null!;
            MainResearcher = null!;
            Group = null!;
        }
    }
}
