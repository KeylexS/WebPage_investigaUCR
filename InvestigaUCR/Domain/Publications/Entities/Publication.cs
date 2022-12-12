/*
    US ID: PIIB22II02-317
    US name: HT-PB-1.4 Base publication, DOI, authors and title
    Technical Task Resolved: PIIB22II02-464 Implement Publications Entity
*/
using Domain.ResearchGroups.Entities;
using Domain.People.Entities;
using System.ComponentModel.DataAnnotations;
using Domain.ResearchProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.ResearchGroups.ValueObjects;

namespace Domain.Publications.Entities
{
    public partial class Publication
    {
        public string Name { get; set; }
        [Key]
        public string DOI { get; set; }
        public byte Visibility { get; set; }
        public string Type { get; set; }
        public string Publisher_name { get; set; }
        public string Abstract { get; set; }
        public string Reference { get; set; }
		//public string pageDOI { get; set; }
        public DateTime _Date { get; set; }
        //US: PIIB22II02-504 SD-RG-3.6 Show a preview of the publications on the research group page TT:PIIB22II02-752 Add Reference of publications and groups in domain entities
        public Group? Group { get;  set; }

        private readonly List<Person> _people;
        public IReadOnlyCollection<Person> People => _people.AsReadOnly();
        public ICollection<ResearchProject> _researchProjects;

        public Publication()
        {
            DOI = "";
            Name = "";
            Visibility = 0;
            Type = "";
            Publisher_name = "";
            Abstract = "";
            Reference = "";
            _Date = DateTime.Today;
			_researchProjects = null!;
            _people = null!;
            Group = null;
        }

        public Publication(string doi, string name, byte visibility,
            string type, string publisherName, string abs,
            string reference, DateTime date)
        {
            DOI = doi;
            Name = name;
            Visibility = visibility;
            Type = type;
            Publisher_name = publisherName;
            Abstract = abs;
            Reference = reference;
            _Date = date;
			_researchProjects = new List<ResearchProject>();
            _people = new List<Person>();
        }
        }
    }
