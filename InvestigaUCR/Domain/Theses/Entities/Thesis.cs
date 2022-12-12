using Domain.People.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Theses.Entities
{
    public class Thesis
    {
        public string Title { get; set; }
        public string _Type { get; set; }
        public string? Description { get; set; }
        public int Id { get; set; }
        public DateTime _Date { get; set; }
        public ResearchProject? ResearchProject { get; set; }
        public Group? ResearchGroup { get; set; }

        // Person List for showing theses
        public List<Person> People { get; set; }

        public Thesis()
        {
            Title = "";
            _Type = "";
            Description = "";
            Id = 0;
            _Date = DateTime.Today;
            ResearchProject = null!;
            People = null!;
            ResearchGroup = null!;
        }

        public Thesis(string title,
            string type, int id, DateTime date, string description, List<Person> people)
        {
            Title = title;
            _Type = type;
            Description = description;
            Id = id;
            _Date = date;
            People = people;
        }
    }
}
