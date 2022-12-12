using Domain.ResearchProjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.People.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.ResearchAreas.Entities;
using LanguageExt;
using System.ComponentModel.DataAnnotations;

namespace Domain.ResearchProjects.Entities
{
    public class Collaborate
    {
        public ResearchProjectId ResearchProjectsId { get; set; }
        public ResearchProject ResearchProject { get; set; } = null!;
        public string PeopleId { get; set; } = null!;
        public Person Person { get; set; } = null!;
        public int Orden { get; set; }

        public Collaborate(ResearchProjectId researchProjectsId, ResearchProject researchProject, string peopleId, Person person, int orden)
        {
            ResearchProjectsId = researchProjectsId;
            ResearchProject = researchProject;
            PeopleId = peopleId;
            Person = person;
            Orden = orden;
        }
        public Collaborate()
        {
            ResearchProjectsId = null!;
            ResearchProject = null!;
            PeopleId = "";
            Person = null!;
            Orden = 0;
        }
    }

}
