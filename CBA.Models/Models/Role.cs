using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Models.Models
{
    public enum Status 
    { 
        Inactive,
        Active
    }
    public class Role
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

    }
}
