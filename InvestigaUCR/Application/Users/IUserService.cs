using Domain.People.Entities;
using Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IUserService
    {
        Task Register(string email, string password);

        Task Login(string email, string password);

        Task Logout();

        Task DeleteUser();

        Task<string> GetCurrentUserEmail();

        Task<UserAccount> GetCurrentUserAccount();

        //PIIB22II02-1319 MC - PL - 3.5 Show Logged Users Task:PIIB22II02-1323	Create service to get all users Dev: Sam Cheang 

        Task<IEnumerable<UserRolModel>> GetAllUsersRols();

        Task SaveUserName(UserAccount _userAccount, string? name);

        Task<IEnumerable<string>> GetAllRoles();

        Task AssignRoltoUser(List<string> rolId, User user);

        Task SaveUserLastName(UserAccount _userAccount, string? lastname);

        Task SaveUserImage(UserAccount _userAccount, byte[]? img);
    }
}
