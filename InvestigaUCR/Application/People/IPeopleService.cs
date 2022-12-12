using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.People.Entities;
using Domain.ResearchGroups.DTOs;

//ID US: PIIB22II02-59, task: PIIB22II02-292 Create people service implementation in application

namespace Application.People
{
    public interface IPeopleService
    {
        
        /// <summary>
        /// Service to Get a person by an id (email)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One Person by the id</returns>
        Task<Person?> GetPersonByIdAsync(string? id);

        /// <summary>
        /// Service to get the the list of all people
        /// </summary>
        /// <returns>The list of people</returns>
        Task<IEnumerable<Person>?> GetPeopleAsync();

        /// <summary>
        /// Service to get the a list of Groups of a Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The list of groups of a person</returns>
        // PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-569 Create interface method in domain for show groups by person. driver(AndreyMena), navigator(JoseFNuñez)
        Task<IEnumerable<GroupDTO>> GetGroupsByPersonID(string? Id);

        /// <summary>
        /// Filter the people in the list based on a text
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="people"></param>
        /// <returns>The list of people that cointains the text</returns>
        public IEnumerable<Person>? GetFilteredPeople(string searchText, IEnumerable<Person>? people);

        /// <summary>
        /// Method <c>DetachPerson</c> Detaches an entity from the dbset
        /// </summary>
        /// <param name="group">The person instance to detach</param>
        void DetachPerson(Person person);
        Task<Person?> GetByIdAsyncSingle(string id);

        /// <summary>
        /// Add a person
        /// </summary>
        /// <param name="group">The person instance to add
        Task AddPerson(Person person);

        //Edit person attributes
        Task SavePersonImage(Person person, byte[]? img);

        Task SavePersonUniversity(Person person, string University);
        
        Task DeletePerson(Person person);
    }
}