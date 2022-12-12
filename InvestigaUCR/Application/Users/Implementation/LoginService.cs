// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using Domain.Users;
using Domain.Users.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Users.Implementation
{
    public class LoginService : PageModel
    {
        private readonly ILoginRepository LoginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            LoginRepository = loginRepository;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            await LoginRepository.OnGetAsync(HttpContext, ModelState, Url, returnUrl);
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            return await LoginRepository.OnPostAsync(Input, ModelState, Url, returnUrl);
        }
    }
}
