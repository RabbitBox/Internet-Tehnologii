namespace DrinkAndGo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationInDrink : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drinks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Drinks", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Drinks", "LongDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Drinks", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Drinks", "ImageThumbnailUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drinks", "ImageThumbnailUrl", c => c.String());
            AlterColumn("dbo.Drinks", "ImageUrl", c => c.String());
            AlterColumn("dbo.Drinks", "LongDescription", c => c.String());
            AlterColumn("dbo.Drinks", "ShortDescription", c => c.String());
            AlterColumn("dbo.Drinks", "Name", c => c.String());
        }
    }
}
