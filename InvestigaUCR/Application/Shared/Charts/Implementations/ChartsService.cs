using Application.Shared.Charts;
using Domain.People.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.Repositories;
using Domain.Shared.Charts.Entities;
using Domain.Shared.Charts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Domain.ResearchGroups.Entities.Group;

namespace Application.Shared.Charts.Implementations
{
    //US: PIIB22II02-509 KS-ST-2.2 Create graph to show amount of projects by year. && tt:PIIB22II02-784 Implement Bar Chart Service in Application
    /// <summary>
    /// Class <c>IChartService</c> Interface that defines the Chart services to implement.
    /// </summary>
    internal class ChartsService : IChartService
    {
        private readonly IChartRepository _chartRepository;

        /// <summary>
        /// ChartsService class parameterized constructor. 
        /// </summary>
        /// <param name="barChartRepository">An instance of the Chart repository</param>
        public ChartsService(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        public async Task<Group> getResearchGroupWhitProjects(string id)
        {
            return await _chartRepository.GetResearchGroupsWhitProjectsAsync(id);
        }


        public async Task<BarChart> getPieChartAmountOfPeopleGroup()
        {
            IEnumerable<Group> groups;
            BarChart _groupsPieChart = new BarChart();
            groups = await _chartRepository.GetResearchGroupWhitPeople();
            List<string> labels = groups.Select(g => g.Name.ToString()).ToList();
            List<double> Values = new List<double>();
            foreach (var group in groups)
            {
                Values.Add(group.Person.Count());
            }
            _groupsPieChart = new BarChart("x", labels, Values);
            return _groupsPieChart;
        }

        /// <summary>
        /// Method <c>GetResearchProjectsChartAsync</c>
        /// </summary>
        /// <returns>An IEnumerable<BarChart></returns>
        public async Task<BarChart?> GetResearchProjectsChartAsync()
        {
            return await _chartRepository.GetResearchProjectsChart();
        }

        public Table GetResearchProjectsTable(int startYear, int endYear, IEnumerable<ResearchArea> areas)
        {
            return _chartRepository.GetResearchProjectsTable(startYear, endYear, areas);
        }
        public RadarChart GetRadarChart(IEnumerable<Person> collaborators)
        {
            return _chartRepository.GetRadarChart(collaborators);
        }
    }
}
