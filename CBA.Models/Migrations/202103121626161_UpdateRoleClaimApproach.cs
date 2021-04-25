namespace CBA.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoleClaimApproach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoleClaims", "ClaimID", c => c.Int(nullable: false));
            DropColumn("dbo.RoleClaims", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoleClaims", "Name", c => c.String());
            DropColumn("dbo.RoleClaims", "ClaimID");
        }
    }
}
