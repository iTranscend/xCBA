namespace CBA.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveToRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "IsActive", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "IsActive");
        }
    }
}
