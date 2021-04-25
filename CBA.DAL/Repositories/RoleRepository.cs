using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Models.Models;
using AppContext = CBA.Models.Models.AppContext;

namespace CBA.DAL.Repositories
{
    public class RoleRepository
    {
        private AppContext db = new AppContext();

        public Role GetByName(string name)
        {
            return db.Roles.Where(r => r.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        public IEnumerable<Claim> GetAllClaims()
        {
            return db.Claims.ToList();
        }
    }
}
