namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SeoLink", c => c.String(maxLength: 100));
            AddColumn("dbo.Categories", "MetaKeyword", c => c.String(maxLength: 500));
            AddColumn("dbo.Categories", "MetaDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "Detail", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "Description", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Products", "SeoLink", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "MetaKeyword", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "MetaDescription", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Products", "MetaDescription");
            DropColumn("dbo.Products", "MetaKeyword");
            DropColumn("dbo.Products", "SeoLink");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Detail");
            DropColumn("dbo.Categories", "MetaDescription");
            DropColumn("dbo.Categories", "MetaKeyword");
            DropColumn("dbo.Categories", "SeoLink");
        }
    }
}
