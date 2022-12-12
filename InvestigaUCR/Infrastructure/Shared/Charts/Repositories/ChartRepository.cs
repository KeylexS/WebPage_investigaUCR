using Domain.ResearchProjects.Entities;
using Domain.Shared.Charts.Entities;
using Domain.ResearchProjects.Repositories;
using Domain.Shared.Charts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Domain.ResearchAreas.Entities;
using Domain.People.Entities;
using Microsoft.EntityFrameworkCore;
using CSharpFunctionalExtensions;
using LanguageExt.UnitsOfMeasure;
using System.Runtime.CompilerServices;
using Domain.ResearchGroups.Entities;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Shared.Charts.Repositories
{
    internal class ChartRepository : IChartRepository
    {
        //US: PIIB22II02-509 KS-ST-2.2 Create graph to show amount of projects by year. && tt:PIIB22II02-782 Implement Bar Chart Repository in Infrastructure
        protected readonly GeneralDbContext _researchProjectsDbContext;

        public ChartRepository(GeneralDbContext researchProjectsDbContext)
        {
            _researchProjectsDbContext = researchProjectsDbContext;
        }

        public async Task<Group> GetResearchGroupsWhitProjectsAsync(string groupId)
        {
            _researchProjectsDbContext.ChangeTracker.Clear();
            return await _researchProjectsDbContext.Groups.Include(r => r.ResearchProjects)
                .Include(x => x.ResearchArea).AsAsyncEnumerable()
                .FirstOrDefaultAsync(t => t.Id.ToString() == groupId);
        }

        public async Task<IEnumerable<Group>> GetResearchGroupWhitPeople()
        {
            return await _researchProjectsDbContext.Groups.Include(p => p.Person).ToListAsync();
        }


        // <summary>
        // This method builds a BarChart entity using the return of a stored function "cantidadPorAnno" for the values of each bar.
        // Each year from 2012 to the present is used as the parameter for the stored function.
        // The stored function returns the number of research projects per year.
        // The variable Years contains the labels for the BarChart, the variable ChartType, defines the type of the chart.
        // </summary>
        // <returns> A BarChart entity</returns>
        public async Task<BarChart?> GetResearchProjectsChart()
        {
            string ChartType = "Bar";
            List<string> Years = new List<string>() { "2012", "2013", "2014","2015","2016","2017","2018","2019","2020","2021","2022" };

            List<Double> Values = new List<Double>(11);
            for (int i = 2012; i < 2023; i++)
            {
                Values.Add(Convert.ToDouble(_researchProjectsDbContext.CantidadPorAnno(i)));
            }
            return new BarChart(ChartType,Years,Values);
        }

        public Table GetResearchProjectsTable(int startYear, int endYear, IEnumerable<ResearchArea> areas)
        {
            List<List<string>> values = new List<List<string>>();
            List<string> areaValues;
            List<string> years = new List<string>();
            years.Add(" ");

            for (int i = startYear; i <= endYear; i++)
            {
                years.Add(i.ToString());
            }

            foreach (var area in areas)
            {
                areaValues = new List<string>(); ;
                areaValues.Add(area.Name);
                for (int i = startYear; i <= endYear; i++)
                {
                    var value = _researchProjectsDbContext.CantidadPorAnnoyArea(area.Id, i).ToString();
                    areaValues.Add(value);
                }
                values.Add(areaValues);        
            }
            return new Table(years, values);
        }
        public RadarChart GetRadarChart(IEnumerable<Person> collaborators)
        {

            List<string> labels = new List<string>();
            List<double> values = new List<double>();
  
            foreach(var collaborator in collaborators)
            {
                values.Add(Convert.ToDouble(_researchProjectsDbContext.ColaboradoresPorPublicacion(collaborator.Id)));
                labels.Add(collaborator.Name + " " + collaborator.LastName1);
            }
            return new RadarChart(labels, values);
        }
    }
}
