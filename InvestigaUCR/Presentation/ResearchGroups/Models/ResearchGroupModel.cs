using Domain.ResearchGroups.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ResearchGroups.Models
{
    public class ResearchGroupModel
    {
        public string? Id{ get; set; }
        public string? Name{ get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? Start_Date { get; set; }

    }
}
