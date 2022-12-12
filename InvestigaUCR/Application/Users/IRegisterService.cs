// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Domain.Users;

namespace Application.Users
{
    public interface IRegisterService
    {
        [BindProperty]
        RegisterInputModel Input { get; set; }

        string ReturnUrl { get; set; }

        IList<AuthenticationScheme> ExternalLogins { get; set; }

        Task OnGetAsync(string returnUrl = null);

        Task<IActionResult> OnPostAsync(string returnUrl = null);
    }
}
