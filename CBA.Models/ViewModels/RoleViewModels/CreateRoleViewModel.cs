using CBA.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBA.Models.ViewModels.RoleViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Role name should only contain characters with no white space"), MaxLength(40)]
        public string Name { get; set; }

        public List<int> ClaimIDs { get; set; }

    }
}
