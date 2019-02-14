namespace FoodSort.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restourants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestourantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        RestourantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restourants", t => t.RestourantId, cascadeDelete: true)
                .Index(t => t.RestourantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestourantReviews", "RestourantId", "dbo.Restourants");
            DropIndex("dbo.RestourantReviews", new[] { "RestourantId" });
            DropTable("dbo.RestourantReviews");
            DropTable("dbo.Restourants");
        }
    }
}
