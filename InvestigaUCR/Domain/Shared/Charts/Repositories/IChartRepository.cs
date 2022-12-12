using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.Entities;
using Domain.People.Entities;
using Domain.Shared.Charts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Charts.Repositories
{
    /// US: PIIB22II02-509 KS-ST-2.2 Create graph to show amount of projects by year. && tt:PIIB22II02-772 Implement the BarChart Repository in Domain
    /// <summary>
    /// Interface <c>IBarChartRepository</c> Interface of BarChart repository with all the methods to implement.
    /// </summary>
    public interface IChartRepository
    {
        /// <summary>
        /// Method <c>GetResearchProjectsCharteAsync</c> Get the BarChart.
        /// </summary>
        Task<BarChart?> GetResearchProjectsChart();
        Table GetResearchProjectsTable(int startYear, int endYear, IEnumerable<ResearchArea> areas);

        Task<Group> GetResearchGroupsWhitProjectsAsync(string groupId);
        /// <summary>
        /// Method <c>GetResearchProjectsCharteAsync</c> Get all groups whit the list of people of the group.
        /// </summary>
        Task<IEnumerable<Group>> GetResearchGroupWhitPeople();
        RadarChart GetRadarChart(IEnumerable<Person> collaborators);
    }
}
