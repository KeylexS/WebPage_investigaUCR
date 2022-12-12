using Domain.Core.ValueObjects;
using Domain.People.Entities;
using Domain.People.Repositories;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using LanguageExt.ClassInstances;
using LanguageExt.Pretty;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task Register(string email, string password)
        {
            await UserRepository.RegisterUser(email, password);
        }

        public async Task Login(string email, string password)
        {
            await UserRepository.LoginUser(email, password);
        }

        public async Task Logout()
        {
            await UserRepository.Logout();
        }

        public async Task DeleteUser()
        {
            await UserRepository.DeleteUser();
        }

        public Task<string> GetCurrentUserEmail()
        {
            return UserRepository.GetCurrentUserEmail();
        }

        public Task<UserAccount> GetCurrentUserAccount()
        {
            return UserRepository.GetCurrentUserAccount();
        }

        //PIIB22II02-1319 MC - PL - 3.5 Show Logged Users Task:PIIB22II02-1323	Create service to get all users Dev: Sam Cheang 

        public Task<IEnumerable<UserRolModel>> GetAllUsersRols()
        {
            return UserRepository.GetAllUsers();
        }

        public async Task SaveUserName(UserAccount _userAccount, string? name)
        {
            _userAccount.Name = name;
            await UserRepository.SaveAsync(_userAccount);
        }
        public async Task SaveUserLastName(UserAccount _userAccount, string? lastname)
        {
            _userAccount.LastName1 = lastname;
            await UserRepository.SaveAsync(_userAccount);
        }

        public async Task SaveUserImage(UserAccount _userAccount, byte[]? img)
        {
            _userAccount.ProfilePicture = img;
            await UserRepository.SaveAsync(_userAccount);
        }

        public async Task<IEnumerable<string>> GetAllRoles()
        {
            return await UserRepository.GetAllRoles();
        }

        public Task AssignRoltoUser(List<string> rolId, User user)
        {
            return  UserRepository.AssignRolToUser(rolId, user);
        }
    }
}
