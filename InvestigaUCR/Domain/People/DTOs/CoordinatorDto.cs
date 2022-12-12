using Domain.Core.ValueObjects;
using Domain.People.Entities;
using Domain.People.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.People.DTOs
{
    public class CoordinatorDto : PersonDto
    {
        // PIIB22II02-153 MC-PL-1.6 Organize card of the coordinator role in a research group Task: PIIB22II02-343 Add coordinator Dto
        public string GroupId { get; set; }

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
        public CoordinatorDto(string groupId, string id, RequiredString name, RequiredString lastName1, RequiredString lastName2,
            PersonHighestDegree highestDegree, RequiredString university, byte[]? img)
            : base(id, name, lastName1, lastName2, highestDegree, university, img)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// This non parameter constructor is useful for mock tests.
        /// </summary>
        public CoordinatorDto(string groupId)
        {
            GroupId = groupId;
        }
    }
}
