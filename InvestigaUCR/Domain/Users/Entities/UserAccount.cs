using Domain.Core.ValueObjects;
using Domain.People.ValueObjects;
using LanguageExt.Pretty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PIIB22II02-1225 MC-PL-5.13 User account details | Add UserAccount entity for account information

namespace Domain.Users.Entities
{
    public class UserAccount
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public string? Descripcion { get; set; } 
        public byte[]? ProfilePicture { get; set; }

        public UserAccount(string id, string email, string name, string lastName1, string lastName2,
            string descripcion, byte[]? profilePicture)
        {
            Id = id;
            Email = email;
            Name = name;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Descripcion = descripcion;
            ProfilePicture = profilePicture;
        }
    }
}
