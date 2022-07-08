using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.EF;
using System.Collections.Generic;
using System.Linq;

namespace OlexShop.Infrastructure.Data
{
    public class AdminAuthenticationRepository : IAdminAuthenticationRepository
    {
        private readonly DemoContext context;
        public AdminAuthenticationRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<AdminAuthentication> GetAdmins()
        {
            return context.AdminAuthentication.ToList();
        }
        public void AddAdmin(AdminAuthentication admin)
        {
            context.AdminAuthentication.Add(admin);
            context.SaveChanges();
        }
        public void DeleteAdmin(int id)
        {
            context.AdminAuthentication.Remove(new AdminAuthentication() { UsernameId = id });
            context.SaveChanges();
        }
    }
}
