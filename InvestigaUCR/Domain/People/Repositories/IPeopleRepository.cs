using Domain.People.Entities;
using Domain.People.Relations;
using Domain.ResearchGroups.DTOs;
using Domain.Publications.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using Domain.People.DTOs;
using Domain.ResearchProjects.Entities;

//ID US: PIIB22II02-59, task: PIIB22II02-291 Create people repository in domain

namespace Domain.People.Repositories
{
    /// <summary>
    /// Interface IPeopleRepository. Interface to handle the database
    /// </summary>
    public interface IPeopleRepository : IRepository<Person>
    {

        /// <summary>
        /// Get a person by an id (email)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One Person by the id</returns>
        Task<Person?> GetByIdAsync(string? id);

        /// <summary>
        /// Get the the list of all people
        /// </summary>
        /// <returns>The list of people</returns>
        Task<IEnumerable<Person>?> GetAllAsync();

        /// <summary>
        /// Get the a list of Groups of a Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The list of groups of a person</returns>
        // PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-569 Create interface method in domain for show groups by person. driver(AndreyMena), navigator(JoseFNuñez)
        Task<IEnumerable<GroupDTO>> GetGroupsByPersonID(string? id);

        /// <summary>
        /// Method <c>Detach group</c> Detaches an entity from the dbset
        /// </summary>
        /// <param name="person">The person instance to detach</param>
        void DetachPerson(Person person);
        Task<Person?> GetByIdAsyncSingle(string id);

        /// <summary>
        /// Add a person to the database
        /// </summary>
        /// <param name="person">The person instance to add
        Task CreatePerson(Person person);

        Task SaveAsync(Person person);
        Task DeletePerson(Person person);
    }
}
