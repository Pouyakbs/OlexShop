using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface IUserAuthenticationRepository
    {
        List<UserAuthentication> GetAuthentications();
        void AddUser(UserAuthentication authentication);
        void DeleteUser(int id);
        public UserAuthentication UserProfile(int id);
    }
}
