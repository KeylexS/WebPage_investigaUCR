using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Core.ValueObjects;
using Domain.People.ValueObjects;

namespace Domain.People.DTOs
{
    public class PersonDto
    {
        /// <summary>
        /// Id is the email of a Person
        /// </summary>
        public string Id { get; }

        public RequiredString Name { get; }

        public RequiredString LastName1 { get; }

        public RequiredString LastName2 { get; }

        public PersonHighestDegree HighestDegree { get; }

        public RequiredString University { get; }

        public byte[]? ProfilePicture { get; set; }

        /// <summary>
        /// Constructor of the PersonDto Class
        /// </summary>
        /// <param name="id">Email of a person</param>
        /// <param name="name"></param>
        /// <param name="lastname1"></param>
        /// <param name="lastname2"></param>
        /// <param name="highestDegree"></param>
        /// <param name="university"></param>
        public PersonDto(string id, RequiredString name, RequiredString lastName1, RequiredString lastName2,
                         PersonHighestDegree highestDegree, RequiredString university, byte[]? profilePicture)
        {
            Id = id;
            Name = name;
            LastName1 = lastName1;
            LastName2 = lastName2;
            HighestDegree = highestDegree;
            University = university;
            ProfilePicture = profilePicture;
        }

        /// <summary>
        /// This non parameter constructor is useful for mock tests.
        /// </summary>
        public PersonDto()
        {
            Id = "";
            Name = null!; // luego poner sin nada
            LastName1 = null!;
            LastName2 = null!;
            HighestDegree = null!;
            University = null!;
            ProfilePicture = null!;
        }
    }
}
