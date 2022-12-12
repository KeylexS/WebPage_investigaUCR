using Domain.Core.ValueObjects;
using Domain.People.ValueObjects;
using Domain.Publications.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.People.Entities
{
    // PIIB22II02-153 MC-PL-1.6 Organize card of the coordinator role in a research group Task: PIIB22II02-347 Add Coordinator in Class
    public class Coordinator : Person
    {
        public string? GroupId { get; set; }

        /// <summary>
        /// Constructor of the Coordinator Class
        /// </summary>
        /// <param name="id">Email of a person</param>
        /// <param name="name"></param>
        /// <param name="lastname1"></param>
        /// <param name="lastname2"></param>
        /// <param name="highestDegree"></param>
        /// <param name="university"></param>
        /// <param name="img">The profile picture of a person</param>
        public Coordinator(string groupId, string id, RequiredString name, RequiredString lastName1, RequiredString lastName2,
            PersonHighestDegree highestDegree, RequiredString university, byte[]? img)
            : base(id, name, lastName1, lastName2, highestDegree, university, img)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// This non parameter constructor is useful for mock tests.
        /// </summary>
        public Coordinator()
        {
            GroupId = "";
        }

        public void AssignGroup(string? groupId) 
        {
            GroupId = groupId;
        }
    }
}
