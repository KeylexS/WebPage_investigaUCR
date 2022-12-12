using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Charts.Entities
{
    /// US: PIIB22II02-509 KS-ST-2.2 Create graph to show amount of projects by year. && tt:PIIB22II02-748 Implement BarChart class in Domain
    /// <summary>
    /// Class <c>BarChart</c> The model to create a chart. Contains the data and type of the chart.
    /// </summary>
    public class BarChart
    {
        public string ChartType { get; set; }
        public List<string> Labels { get; set; }
        public List<double> Values { get; set; }

        /// <summary>
        /// BarChart class default constructor.
        /// </summary>
        public BarChart()
        {
            ChartType = "";
            Labels = null!;
            Values = null!;

        }

        /// <summary>
        /// BarChart class parameterized constructor.
        /// </summary>
        /// <param name="chartType">The type of chart</param>
        /// <param name="labels">The values labels of the Chart data</param>
        /// <param name="values">The values of the Chart data</param>
        public BarChart(string chartType, List<string> labels, List<double> values)
        {
            ChartType = chartType;
            Labels = labels;
            Values = values;
        }
    }
}
