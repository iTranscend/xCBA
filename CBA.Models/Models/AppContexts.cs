using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CBA.Models.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<GlCategory> GlCategories { get; set; }
        public DbSet<GlAccount> GlAccounts { get; set; }
        public DbSet<TillToUser> TillToUsers { get; set; }
        public DbSet<AccountConfiguration> AccountConfigurations { get; set; }
    }
}
