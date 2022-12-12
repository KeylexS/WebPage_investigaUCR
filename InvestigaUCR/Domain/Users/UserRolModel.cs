using Domain.Core.ValueObjects;
using Domain.People.ValueObjects;
using LanguageExt.Pretty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PIIB22II02-1319 MC - PL - 3.5 Show Logged Users Task: PIIB22II02-1321	Create model display of users Dev: Sam Cheang 

namespace Domain.Users.Entities
{
    public class UserRolModel
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public UserRolModel(string id, string email)
        {
            Id = id;
            Email = email;
            Roles = new List<string>();
        }

        public UserRolModel()
        {
            Id = "";
            Email = "";
            Roles = null;
        }
    }
}
