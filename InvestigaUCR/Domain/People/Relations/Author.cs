using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.People.Entities;
using Domain.Publications.Entities;

//PIIB22II02 - 190 MC - PL - 2.3 Show publications associated with a person | Task: PIIB22II02 - 587 Create Author entity. 

namespace Domain.People.Relations
{
    /// <summary>
    /// Class Author Model the relationship between Person and Publication
    /// </summary>
    public class Author
    {
        // Attributes of the relationship
        public string? DOI { get; }
        public string? Id { get; }
        public int Order { get; }

        // Entities 
        public Publication? Publication { get; }
        public Person? People { get; }

        /// <summary>
        /// Constructor of Author relation for Unit testing
        /// </summary>
        /// <param name="doi">Doi of the publication</param>
        /// <param name="id">Id of the person</param>
        /// <param name="order">Sort of each person</param>
        /// <param name="publication"></param>
        /// <param name="person"></param>
        public Author(string? doi, string? id, int order, Publication? publication, Person? person)
        {
            DOI = doi;
            Id = id;
            Order = order;
            Publication = publication;
            People = person;
        }

        /// <summary>
        /// Empty constructor for Unit testing
        /// </summary>
        public Author()
        {
            DOI = "";
            Id = "";
            Order = 0;
            Publication = null;
            People = null;
        }
    }
}
