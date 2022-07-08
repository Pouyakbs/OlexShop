using OlexShop.Core.Domain.Entities;
using System.Collections.Generic;

namespace OlexShop.Core.Contracts.Repository
{
    public interface IAdminAuthenticationRepository
    {
        List<AdminAuthentication> GetAdmins();
        void AddAdmin(AdminAuthentication admin);
        void DeleteAdmin(int id);
    }
}
