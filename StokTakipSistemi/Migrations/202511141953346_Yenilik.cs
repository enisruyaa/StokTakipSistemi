namespace StokTakipSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yenilik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "Order_ID", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Product_ID" });
            DropIndex("dbo.ProductOrders", new[] { "Order_ID" });
            DropTable("dbo.ProductOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_ID = c.Int(nullable: false),
                        Order_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Order_ID });
            
            CreateIndex("dbo.ProductOrders", "Order_ID");
            CreateIndex("dbo.ProductOrders", "Product_ID");
            AddForeignKey("dbo.ProductOrders", "Order_ID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrders", "Product_ID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
