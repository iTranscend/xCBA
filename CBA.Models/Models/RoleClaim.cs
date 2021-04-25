using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Models.Models
{
    public class RoleClaim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int ClaimID { get; set; }
        public virtual Role Role { get; set; }
        public virtual Claim Claim { get; set; }
    }
}
