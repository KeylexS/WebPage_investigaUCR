using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Charts.Entities
{
    public class Table
    {
        public List<string>? Labels { get; set; }
        public List<List<string>>? Values { get; set; }

        public Table()
        {
            Labels = null!;
            Values = null!; 

        }

        public Table(List<string>? labels, List<List<string>>? values)
        {
            Labels = labels;
            Values = values;
        }
    }


}
