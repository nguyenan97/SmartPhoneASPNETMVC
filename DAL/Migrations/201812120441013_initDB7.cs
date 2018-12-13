namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Status");
        }
    }
}
