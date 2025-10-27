namespace StokTakipSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.OrderID });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        OrderDetail_ProductID = c.Int(),
                        OrderDetail_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderDetails", t => new { t.OrderDetail_ProductID, t.OrderDetail_OrderID })
                .Index(t => new { t.OrderDetail_ProductID, t.OrderDetail_OrderID });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockQuantity = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        OrderDetail_ProductID = c.Int(),
                        OrderDetail_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderDetails", t => new { t.OrderDetail_ProductID, t.OrderDetail_OrderID })
                .Index(t => new { t.OrderDetail_ProductID, t.OrderDetail_OrderID });
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_ID = c.Int(nullable: false),
                        Order_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Order_ID })
                .ForeignKey("dbo.Products", t => t.Product_ID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_ID, cascadeDelete: true)
                .Index(t => t.Product_ID)
                .Index(t => t.Order_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" }, "dbo.OrderDetails");
            DropForeignKey("dbo.Orders", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" }, "dbo.OrderDetails");
            DropForeignKey("dbo.ProductOrders", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_ID", "dbo.Products");
            DropIndex("dbo.ProductOrders", new[] { "Order_ID" });
            DropIndex("dbo.ProductOrders", new[] { "Product_ID" });
            DropIndex("dbo.Products", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" });
            DropIndex("dbo.Orders", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" });
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
