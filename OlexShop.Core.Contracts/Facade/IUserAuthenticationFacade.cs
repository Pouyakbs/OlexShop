using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface IUserAuthenticationFacade
    {
        IEnumerable<UserAuthenticationDTO> GetAuthentications();
        void AddUser(UserAuthenticationDTO userAuthentication);
        void DeleteUser(int id);
        public UserAuthenticationDTO UserProfile(int id);
    }
}
