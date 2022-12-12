using Domain.Core.ValueObjects;
using Domain.People.ValueObjects;
using Domain.Publications.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.People.Entities
{
    // PIIB22II02-370 MC-PL-1.8 Organize card of the researcher role in a research group Task: PIIB22II02-835 Add tables of Researcher
    public class Researcher : Person
    {
        public string GroupId { get; set; }

        /// <summary>
        /// Constructor of the reseacher Class
        /// </summary>
        /// <param name="id">Email of a person</param>
        /// <param name="name"></param>
        /// <param name="lastname1"></param>
        /// <param name="lastname2"></param>
        /// <param name="highestDegree"></param>
        /// <param name="university"></param>
        /// <param name="img">The profile picture of a person</param>
        public Researcher(string groupId, string id, RequiredString name, RequiredString lastName1, RequiredString lastName2,
            PersonHighestDegree highestDegree, RequiredString university, byte[]? img)
            : base(id, name, lastName1, lastName2, highestDegree, university, img)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// This non parameter constructor is useful for mock tests.
        /// </summary>
        public Researcher(string groupId)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// Default constructor for class Researcher.
        /// </summary>
        public Researcher()
        {
            GroupId = "";
        }
    }
}
