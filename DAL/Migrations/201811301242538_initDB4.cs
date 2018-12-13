namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "SeoLink", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "SeoLink", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "MetaKeyword", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "MetaDescription", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "MetaDescription", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "MetaKeyword", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "SeoLink", c => c.String(maxLength: 100));
            AlterColumn("dbo.Categories", "SeoLink", c => c.String(maxLength: 100));
        }
    }
}
