namespace FoodSort.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestourantReviews", "RevierName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestourantReviews", "RevierName");
        }
    }
}
