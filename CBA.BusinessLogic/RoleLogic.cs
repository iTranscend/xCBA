using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.DAL.Repositories;
using CBA.Models.Models;

namespace CBA.BusinessLogic
{
    public class RoleLogic
    {
        RoleRepository roleRepo = new RoleRepository();
        public bool isRoleNameExists(string name)
        {
            if (roleRepo.GetByName(name) == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Claim> getAllClaims()
        {
            return roleRepo.GetAllClaims();
        }
    }
}
