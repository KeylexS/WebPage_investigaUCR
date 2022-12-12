using Domain.People.Entities;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Infrastrucute.Identity;
using LanguageExt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly SignInManager<User> SignInManager;

        protected readonly UserManager<User> UserManager;

        protected readonly IAuthenticationService AuthorizationService;

        protected readonly AuthenticationStateProvider AuthenticationStateProvider;

        protected readonly ApplicationDbContext _dbContext;

        public UserRepository(SignInManager<User> signInManager, UserManager<User> userManager,
            IAuthenticationService authorizationService, AuthenticationStateProvider authenticationStateProvider,
            ApplicationDbContext applicationDbContext)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            AuthorizationService = authorizationService;
            AuthenticationStateProvider = authenticationStateProvider;
            _dbContext = applicationDbContext;
        }

        public async Task RegisterUser(string email, string password)
        {
            var user = new User { UserName = email, Email = email };
            await UserManager.CreateAsync(user, password);
        }

        public async Task LoginUser(string email, string password)
        {
            await SignInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
        }

        public async Task Logout()
        {
            await SignInManager.SignOutAsync();
        }

        public async Task DeleteUser()
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(u => u.Id == GetCurrentUserAccount().Result.Id);
            await UserManager.DeleteAsync(user.Result!);
        }

        public Task<UserAccount> GetCurrentUserAccount()
        {
            var authState = AuthenticationStateProvider.GetAuthenticationStateAsync();
            var userEmail = GetCurrentUserEmail().Result;
            if (userEmail != "")
            {
                return Task.FromResult( _dbContext.UserAccounts.FirstOrDefaultAsync(t => t.Email == userEmail).Result!);
            }
            else
            {
                return null!;
            }
        }

        public Task<string> GetCurrentUserEmail()
        {
            var authState = AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.Result.User.Identity!.IsAuthenticated)
            {
                return Task.FromResult(authState.Result.User.Identity.Name!.ToString());
            }
            else
            {
                return Task.FromResult("");
            }
        }

        //PIIB22II02-1319 MC - PL - 3.5 Show Logged Users Task: PIIB22II02-1322 Create getallusers repository Dev: Sam Cheang 

        public async Task<IEnumerable<UserRolModel>> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            var userRoles = new List<UserRolModel>();
            foreach (User user in users)
            {
                var model = new UserRolModel();
                model.Id = user.Id;
                model.Email = user.Email;
                var roles = await UserManager.GetRolesAsync(user);
                List<string> temp = new List<string>();
                foreach (var rol in roles)
                {
                    temp.Add(rol.ToString());
                }
                model.Roles = temp;
                userRoles.Add(model);
            }
            return userRoles;
        }

        public async Task SaveAsync(UserAccount user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetAllRoles()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            var rolesAux = new List<string>();

            foreach (var rol in roles)
            {
                rolesAux.Add(rol.Id);
            }
            return rolesAux;
        }

        public async Task AssignRolToUser(List<string> rolId, User user)
        {
            
            await UserManager.AddToRolesAsync(user, rolId);
        }
    }
}
