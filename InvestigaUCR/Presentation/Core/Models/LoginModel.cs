using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.Colors;

//PIIB22II02-469 MC-PL-5.2 Login user account | PIIB22II02-976 Create login model driver(Andrey) navigators(Sam, Josef, Grevin)

namespace Presentation.Core.Models
{
    public class LoginModel
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
