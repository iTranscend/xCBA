using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Models.Models;

namespace CBA.Models.ViewModels.RoleViewModels
{
    public class EditRoleViewModel
    {
        public int RoleId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Role name should only contain characters with no white space"), MaxLength(40)]
        public string Name { get; set; }

        public List<int> ClaimIDs { get; set; }

        public Role Role { get; set; }

        public IEnumerable<RoleClaim> RoleClaims { get; set; }
    }
}
