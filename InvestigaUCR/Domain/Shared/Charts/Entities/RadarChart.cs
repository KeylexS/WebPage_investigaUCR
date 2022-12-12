using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Charts.Entities
{
    public class RadarChart
    {
        public List<string>? Labels { get; set; }
        public List<double>? Values { get; set; }

        /// <summary>
        /// BarChart class default constructor.
        /// </summary>
        public RadarChart()
        {
            Labels = null!;
            Values = null!;

        }

        public RadarChart(List<string>? labels, List<double>? values)
        {
            Labels = labels;
            Values = values;
        }
    }
}
