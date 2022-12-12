using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.People;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.People.Models
{
    public class PersonModel : PageModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public string? HighestDegree { get; set; }
        public string? University { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
