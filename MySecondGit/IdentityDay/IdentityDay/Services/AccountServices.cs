using IdentityDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityDay.Services
{    

    public class AccountServices
    {
        private IRepository _repo;

        public AccountServices(IRepository repo)
        {
            _repo = repo;
        }

        public IList<ApplicationUser> ListUsers()
        {
           
            return _repo.Query<ApplicationUser>().ToList();            

        }

        public ApplicationUser FindUser(string username)
        {
            return _repo.Query<ApplicationUser>().FirstOrDefault(u => u.UserName == username);


            //var targetAccount = _repo.Query<Account>().First(t => t.Username == username);
        }
    }
}