using CBA.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Models.ViewModels.RoleViewModels
{
    public class RoleClaimsViewModel
    {
        public Role Role { get; set; }
        public IEnumerable<RoleClaim> RoleClaims { get; set; }
    }
}
