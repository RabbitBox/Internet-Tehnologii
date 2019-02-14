namespace DrinkAndGo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingCartItemm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        ShoppingCartItemId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ShoppingCartId = c.String(),
                        DrinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartItemId)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .Index(t => t.DrinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartItems", "DrinkId", "dbo.Drinks");
            DropIndex("dbo.ShoppingCartItems", new[] { "DrinkId" });
            DropTable("dbo.ShoppingCartItems");
        }
    }
}
