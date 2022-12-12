using Domain.People.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.Entities;
using Domain.Shared.Charts.Entities;
using Domain.Shared.Charts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared
{
    /// <summary>
    /// Class <c>IChartService</c> Interface that defines the Chart services to implement.
    /// </summary>
    public interface IChartService
    {
        /// <summary>
        /// Method <c>GetResearchProjectsChartAsync</c>
        /// </summary>
        /// <returns>An IEnumerable<BarChart></returns>
        Task<BarChart> GetResearchProjectsChartAsync();
        Table GetResearchProjectsTable(int startYear, int endYear, IEnumerable<ResearchArea> areas);
        Task<Group> getResearchGroupWhitProjects(string id);

        Task<BarChart> getPieChartAmountOfPeopleGroup();
        RadarChart GetRadarChart(IEnumerable<Person> collaborators);
    }
}
