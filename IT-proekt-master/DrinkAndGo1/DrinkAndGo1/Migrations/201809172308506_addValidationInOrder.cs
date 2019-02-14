namespace DrinkAndGo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidationInOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "AddressLine1", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "ZipCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "State", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Orders", "Country", c => c.String());
            AlterColumn("dbo.Orders", "State", c => c.String());
            AlterColumn("dbo.Orders", "ZipCode", c => c.String());
            AlterColumn("dbo.Orders", "AddressLine1", c => c.String());
            AlterColumn("dbo.Orders", "LastName", c => c.String());
            AlterColumn("dbo.Orders", "FirstName", c => c.String());
        }
    }
}
