namespace StokTakipSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aciklamasil : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
        }
    }
}
