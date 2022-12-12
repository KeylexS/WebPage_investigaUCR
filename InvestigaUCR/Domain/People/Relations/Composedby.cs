using System;
using System.Linq;
using System.Text;
using LanguageExt.Pretty;
using System.Threading.Tasks;
using System.Collections.Generic;
using LanguageExt.ClassInstances;
using Domain.ResearchGroups.ValueObjects;

//PIIB22II02-59 MC - PL - 1.3 People list in the research group. Add composed_by(relation between group and person)

namespace Domain.People.Relations
{
    /// <summary>
    /// Class Author Model the relationship between Person and Publication
    /// </summary>
    public class Composedby
    {
        public string? researchGroupID { get; }

        public string? personalIdentification { get; }

        /// <summary>
        /// Constructor of Composedby for testing
        /// </summary>
        /// <param name="researchGroupId">Id of the group</param>
        /// <param name="personalId">Id of the person</param
        public Composedby(string? researchGroupId, string? personalId)
        {
            researchGroupID = researchGroupId;
            personalIdentification = personalId;
        }

        /// <summary>
        /// Empty Constructor for testing
        /// </summary>
        public Composedby()
        {
            researchGroupID = "";
            personalIdentification = "";
        }
    }
}