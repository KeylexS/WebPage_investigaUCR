using System;
using System.Linq;
using System.Text;
using LanguageExt;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.People.Entities;
using Domain.People.Repositories;
using Domain.ResearchGroups.DTOs;
using Application.Shared.StringManipulation.Implementations;
using Microsoft.EntityFrameworkCore;
using Domain.Core.ValueObjects;
using Domain.Core.Helpers;

//ID US: PIIB22II02-59, task: PIIB22II02-292 Create people service implementation in application

namespace Application.People.Implementations
{
    public class PeopleServices : IPeopleService
    {

        private readonly IPeopleRepository _peopleRepository;

        public PeopleServices(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        /// <summary>
        /// Service to Get a person by an id (email)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One Person by the id</returns>
        public async Task<Person?> GetPersonByIdAsync(string? id)
        {
            return await _peopleRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Service to get the the list of all people
        /// </summary>
        /// <returns>The list of people</returns>
        public async Task<IEnumerable<Person>?> GetPeopleAsync()
        {
            return await _peopleRepository.GetAllAsync();
        }

        /// <summary>
        /// Service to get the a list of Groups of a Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The list of groups of a person</returns>
        // PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-569 Create interface method in domain for show groups by person. driver(AndreyMena), navigator(JoseFNuñez)
        public async Task<IEnumerable<GroupDTO>> GetGroupsByPersonID(string? Id) {
            return await _peopleRepository.GetGroupsByPersonID(Id);
        }

        /// <summary>
        /// Filter the people in the list based on a text
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="people"></param>
        /// <returns>The list of people that cointains the text</returns>
        public IEnumerable<Person>? GetFilteredPeople(string searchText, IEnumerable<Person>? people)
        {
            StringManipulationService stringManipulation = new StringManipulationService();

            return people?.AsEnumerable()
            .Where(person =>
                stringManipulation.standarizeText(person.Name.ToString().ToLower())
                .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                || stringManipulation.standarizeText(person.HighestDegree.ToString().ToLower())
                                     .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                || stringManipulation.standarizeText(person.Id.ToString().ToLower())
                                     .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                || stringManipulation.standarizeText(person.LastName1.ToString().ToLower())
                                     .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                || stringManipulation.standarizeText(person.LastName2.ToString().ToLower())
                                     .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                || stringManipulation.standarizeText(person.University.ToString().ToLower())
                                     .Contains(stringManipulation.standarizeText(searchText.ToLower()))
                ).AsEnumerable();
        }

        public void DetachPerson(Person person)
        {
            _peopleRepository.DetachPerson(person);
        }

        public async Task<Person?> GetByIdAsyncSingle(string id)
        {
            return await _peopleRepository.GetByIdAsyncSingle(id);
        }
        public async Task AddPerson(Person person)
        {
            await _peopleRepository.CreatePerson(person);
        }
        public async Task SavePersonImage(Person _person, byte[]? img)
        {
            _person.ProfilePicture = img;
            await _peopleRepository.SaveAsync(_person);
        }

        public async Task SavePersonUniversity(Person _person, string? University)
        {
            _person.SetUniversity(RequiredString.TryCreate(University).Success());
            await _peopleRepository.SaveAsync(_person);
        }

        public async Task DeletePerson(Person person)
        {
            await _peopleRepository.DeletePerson(person);
        }
    }
}
