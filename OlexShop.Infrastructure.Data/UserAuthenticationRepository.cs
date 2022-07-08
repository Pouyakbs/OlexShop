using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlexShop.Infrastructure.Data
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly DemoContext Context;
        public UserAuthenticationRepository(DemoContext Context)
        {
            this.Context = Context;
        }
        public List<UserAuthentication> GetAuthentications()
        {
            return Context.UserAuthentication.ToList();
        }
        public void AddUser(UserAuthentication userAuthentication)
        {
            Context.UserAuthentication.Add(userAuthentication);
            Context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            Context.UserAuthentication.Remove(new UserAuthentication() { UsernameId = id });
            Context.SaveChanges();
        }
        public UserAuthentication UserProfile(int id)
        {
            return Context.UserAuthentication.Find(id);
        }
    }
}
