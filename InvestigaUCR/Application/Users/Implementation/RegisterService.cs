// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Users.Repositories;
using Domain.Users;

namespace Application.Users.Implementation
{
    public class RegisterService : PageModel
    {
        private readonly IRegisterRepository RegisterRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            RegisterRepository = registerRepository;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            await RegisterRepository.OnGetAsync(returnUrl);
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            return await RegisterRepository.OnPostAsync(Input, Request, ModelState, Url, returnUrl);
        }
    }
}
