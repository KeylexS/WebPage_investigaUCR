// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Domain.Users.Repositories
{
    public interface IRegisterRepository
    {
        Task OnGetAsync(string returnUrl = null);

        Task<IActionResult> OnPostAsync(RegisterInputModel Input, HttpRequest Request, ModelStateDictionary ModelState, IUrlHelper Url, string returnUrl = null);
    }
}
