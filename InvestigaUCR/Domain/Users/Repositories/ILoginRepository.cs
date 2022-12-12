#nullable disable
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Domain.Users.Repositories
{
    public interface ILoginRepository
    {
        Task OnGetAsync(HttpContext HttpContext, ModelStateDictionary ModelState, IUrlHelper Url, string returnUrl = null);

        Task<IActionResult> OnPostAsync(LoginInputModel Input, ModelStateDictionary ModelState, IUrlHelper Url, string returnUrl = null);
    }
}
