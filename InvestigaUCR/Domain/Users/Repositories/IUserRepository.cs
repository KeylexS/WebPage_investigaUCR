using Domain.Core.Repositories;
using Domain.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task RegisterUser(string email, string password);

        Task LoginUser(string email, string password);

        Task Logout();

        Task DeleteUser();

        Task<string> GetCurrentUserEmail();

        Task<UserAccount> GetCurrentUserAccount();

        //PIIB22II02-1319 MC - PL - 3.5 Show Logged Users Task: PIIB22II02-1322 Create getallusers repository Dev: Sam Cheang 

        Task<IEnumerable<UserRolModel>> GetAllUsers();

        Task SaveAsync(UserAccount user);

        Task<IEnumerable<string>> GetAllRoles();

        Task AssignRolToUser(List<string> rolId, User user);
    }
}
