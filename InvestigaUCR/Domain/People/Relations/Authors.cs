using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.People.Entities;
using Domain.Theses.Entities;

// PIIB22II02-524 MC-PL-2.7 Show thesis associated with a person | task: PIIB22II02-1041 Create Authors entity

namespace Domain.People.Relations
{
    /// <summary>
    /// Class Authors Model the relation between Person and Thesis
    /// </summary>
    public class Authors
    {
        // Atributes of the relation
        public string? IdPerson { get; }
        public int IdThesis { get; }
        public int Order { get;  }

        // Entities
        public Thesis? Theses { get; }
        public Person? People { get; }

        /// <summary>
        /// Parametrized constructor of Authors relation
        /// </summary>
        /// <param name="Id_Person">The person Id</param>
        /// <param name="Id_Thesis">The thesis Id</param>
        /// <param name="order">The order of the thesis</param>
        /// <param name="theses">A Thesis entity</param>
        /// <param name="people">A Person entity</param>
        public Authors(string? Id_Person, int Id_Thesis, int order, Thesis? theses, Person? people)
        {
            IdPerson = Id_Person;
            IdThesis = Id_Thesis;
            Order = order;
            Theses = theses;
            People = people;
        }

        /// <summary>
        /// Default constructor of Authors relation
        /// </summary>
        public Authors()
        {
            IdPerson = "";
            IdThesis = 0;
            Order = 0;
            Theses = null;
            People = null;
        }
    }
}
