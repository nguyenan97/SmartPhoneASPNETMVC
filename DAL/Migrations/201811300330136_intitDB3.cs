namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryImage", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryImage");
        }
    }
}
