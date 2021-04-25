namespace CBA.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GlAccountsSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountName = c.String(nullable: false, maxLength: 40),
                        CodeNumber = c.Long(nullable: false),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GlCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GlCategories", t => t.GlCategoryID, cascadeDelete: true)
                .Index(t => t.GlCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GlAccounts", "GlCategoryID", "dbo.GlCategories");
            DropIndex("dbo.GlAccounts", new[] { "GlCategoryID" });
            DropTable("dbo.GlAccounts");
        }
    }
}
