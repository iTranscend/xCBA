using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Models.Models;

namespace CBA.DAL.Repositories
{
    public class UserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUser GetByUsername(string username)
        {
            return db.Users.Where(u => u.UserName.ToLower().Equals(username.ToLower())).FirstOrDefault();
        }

        public ApplicationUser GetByEmail(string email)
        {
            return db.Users.Where(u => u.Email.ToLower().Equals(email.ToLower())).FirstOrDefault();
        }
        public ApplicationUser FindUser(string username, string passwordHash)
        {
            return db.Users.Where(u => u.UserName.ToLower().Equals(username.ToLower()) && u.PasswordHash.ToLower().Equals(passwordHash.ToLower())).FirstOrDefault();
        }

        public object GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public object GetAllUsersByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAllWithEmailConfirmed()
        {
            return db.Users.Where(u => u.EmailConfirmed == true).ToList();
        }
    }
}
