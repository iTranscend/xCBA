namespace CBA.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableUserStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Status");
        }
    }
}
