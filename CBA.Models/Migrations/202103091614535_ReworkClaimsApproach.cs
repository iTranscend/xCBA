namespace CBA.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkClaimsApproach : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleClaim2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Claim_ID = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Claims", t => t.Claim_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Claim_ID)
                .Index(t => t.Role_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleClaim2", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.RoleClaim2", "Claim_ID", "dbo.Claims");
            DropIndex("dbo.RoleClaim2", new[] { "Role_ID" });
            DropIndex("dbo.RoleClaim2", new[] { "Claim_ID" });
            DropTable("dbo.RoleClaim2");
            DropTable("dbo.Claims");
        }
    }
}
