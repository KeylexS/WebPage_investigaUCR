using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LanguageExt.Pretty;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.ResearchProjects.Entities;
using Domain.Publications.Entities;
using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.People.ValueObjects;
using Domain.Theses.Entities;
using Domain.ResearchGroups.Entities;

//ID US: PIIB22II02-59, task: PIIB22II02-290 Create person entitie in domain

namespace Domain.People.Entities
{

    public class Person : AggregateRoot
    {
        /// <summary>
        /// Id is the email of a Person
        /// </summary>
        public string Id { get; set; }
        public RequiredString Name { get; set; }
        public RequiredString LastName1 { get; set; }
        public RequiredString LastName2 { get; set; }
        public PersonHighestDegree HighestDegree { get; private set; }
        public RequiredString University { get; private set; }
        public List<ResearchProject> ResearchProjects { get; set; }
        public byte[]? ProfilePicture { get; set; }

        // Associated elements of
        public List<ResearchProject> MRResearchProjects { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Thesis> Theses { get; set; }
        public ICollection<Collaborate> Collaborates { get; set; }

        public List<Group> CoordinatorGroups { get; set; }

        public List<Group> ResearchGroup { get; set; }

        //private readonly List<Group> _researchGroup;
        //public IReadOnlyCollection<Group> ResearchGroup => _researchGroup.AsReadOnly();

        /// <summary>
        /// Constructor of the Person Class
        /// </summary>
        /// <param name="id">Email of a person</param>
        /// <param name="name"></param>
        /// <param name="lastname1"></param>
        /// <param name="lastname2"></param>
        /// <param name="highestDegree"></param>
        /// <param name="university"></param>
        /// <param name="img">The profile picture of a person</param>
        public Person(string id, RequiredString name, RequiredString lastName1, RequiredString lastName2,
                      PersonHighestDegree highestDegree, RequiredString university, byte[]? img)
        {
            Id = id;
            Name = name;
            LastName1 = lastName1;
            LastName2 = lastName2;
            HighestDegree = highestDegree;
            University = university;
            ProfilePicture = img;
            ResearchProjects = new List<ResearchProject>();
            Publications = new List<Publication>();
            Collaborates = new List<Collaborate>();       
            MRResearchProjects = new List<ResearchProject>();
            Theses = new List<Thesis>();
            CoordinatorGroups = new List<Group>();
            ResearchGroup = new List<Group>();
            //_researchGroup = new List<Group>();
        }

        /// <summary>
        /// This non parameter constructor is useful for mock tests.
        /// </summary>
        public Person()
        {
            Id = "";
            Name = null!;
            LastName1 = null!;
            LastName2 = null!;
            HighestDegree = null!;
            University = null!;
            ProfilePicture = null!;
            ResearchProjects = null!;
            Publications = null!;
            ProfilePicture = null!;
            Collaborates = null!;
            MRResearchProjects = null!;
            Theses = null!;
            CoordinatorGroups = null!;
            ResearchGroup = null!;
           // _researchGroup = null!;
        }

        public void SetUniversity(RequiredString university)
        {
            University = university;
        }

    }
}
