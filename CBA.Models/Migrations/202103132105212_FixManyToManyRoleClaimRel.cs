namespace CBA.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixManyToManyRoleClaimRel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleClaim2", "Claim_ID", "dbo.Claims");
            DropForeignKey("dbo.RoleClaim2", "Role_ID", "dbo.Roles");
            DropIndex("dbo.RoleClaim2", new[] { "Claim_ID" });
            DropIndex("dbo.RoleClaim2", new[] { "Role_ID" });
            /*CreateIndex("dbo.RoleClaims", "ClaimID");
            AddForeignKey("dbo.RoleClaims", "ClaimID", "dbo.Claims", "ID", cascadeDelete: true);*/
            DropTable("dbo.RoleClaim2");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleClaim2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Claim_ID = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            /*DropForeignKey("dbo.RoleClaims", "ClaimID", "dbo.Claims");
            DropIndex("dbo.RoleClaims", new[] { "ClaimID" });*/
            CreateIndex("dbo.RoleClaim2", "Role_ID");
            CreateIndex("dbo.RoleClaim2", "Claim_ID");
            AddForeignKey("dbo.RoleClaim2", "Role_ID", "dbo.Roles", "ID");
            AddForeignKey("dbo.RoleClaim2", "Claim_ID", "dbo.Claims", "ID");
        }
    }
}
