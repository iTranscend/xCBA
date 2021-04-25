namespace CBA.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatStatusSwitchToEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Roles", "Status");
        }
    }
}
