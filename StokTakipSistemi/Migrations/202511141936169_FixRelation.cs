namespace StokTakipSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" }, "dbo.OrderDetails");
            DropForeignKey("dbo.Products", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" }, "dbo.OrderDetails");
            DropIndex("dbo.Orders", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" });
            DropIndex("dbo.Products", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" });
            CreateIndex("dbo.OrderDetails", "ProductID");
            CreateIndex("dbo.OrderDetails", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            DropColumn("dbo.Orders", "OrderDetail_ProductID");
            DropColumn("dbo.Orders", "OrderDetail_OrderID");
            DropColumn("dbo.Products", "OrderDetail_ProductID");
            DropColumn("dbo.Products", "OrderDetail_OrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "OrderDetail_OrderID", c => c.Int());
            AddColumn("dbo.Products", "OrderDetail_ProductID", c => c.Int());
            AddColumn("dbo.Orders", "OrderDetail_OrderID", c => c.Int());
            AddColumn("dbo.Orders", "OrderDetail_ProductID", c => c.Int());
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            CreateIndex("dbo.Products", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" });
            CreateIndex("dbo.Orders", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" });
            AddForeignKey("dbo.Products", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" }, "dbo.OrderDetails", new[] { "ProductID", "OrderID" });
            AddForeignKey("dbo.Orders", new[] { "OrderDetail_ProductID", "OrderDetail_OrderID" }, "dbo.OrderDetails", new[] { "ProductID", "OrderID" });
        }
    }
}
