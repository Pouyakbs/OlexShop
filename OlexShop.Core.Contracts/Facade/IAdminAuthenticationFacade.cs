using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System.Collections.Generic;

namespace OlexShop.Core.Contracts.Facade
{
    public interface IAdminAuthenticationFacade
    {
        IEnumerable<AdminAuthenticationDTO> GetAuthentications();
        void AddAdmin(AdminAuthenticationDTO admin);
        void DeleteAdmin(int id);
    }
}
