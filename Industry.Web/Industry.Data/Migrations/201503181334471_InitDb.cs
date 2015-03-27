namespace Industry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SerialBidDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BidId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Short(nullable: false),
                        Discount = c.Single(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedId = c.Int(nullable: false),
                        ModifiedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SerialBid", t => t.BidId)
                .ForeignKey("dbo.SerialProduct", t => t.ProductId)
                .Index(t => t.BidId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SerialBid",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ShopperId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        BidDate = c.DateTime(),
                        RequiredDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        ShipVia = c.Int(),
                        Freight = c.Decimal(precision: 18, scale: 2),
                        ShipName = c.String(),
                        ShipAddress = c.String(),
                        ShipCity = c.String(),
                        ShipRegion = c.String(),
                        ShipPostalCode = c.String(),
                        ShipCountry = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedId = c.Int(nullable: false),
                        ModifiedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shopper", t => t.ShopperId)
                .Index(t => t.ShopperId);
            
            CreateTable(
                "dbo.Shopper",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SerialProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        SupplierId = c.Int(),
                        CategoryId = c.Int(),
                        QuantityPerUnit = c.Int(nullable: false),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        UnitsInStock = c.Short(),
                        UnitsOnOrder = c.Short(),
                        ReorderLevel = c.Short(),
                        Discontinued = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SerialCategory", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.SerialCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        Picture = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SerialProduct", "CategoryId", "dbo.SerialCategory");
            DropForeignKey("dbo.SerialBidDetail", "ProductId", "dbo.SerialProduct");
            DropForeignKey("dbo.SerialBid", "ShopperId", "dbo.Shopper");
            DropForeignKey("dbo.SerialBidDetail", "BidId", "dbo.SerialBid");
            DropIndex("dbo.SerialProduct", new[] { "CategoryId" });
            DropIndex("dbo.SerialBid", new[] { "ShopperId" });
            DropIndex("dbo.SerialBidDetail", new[] { "ProductId" });
            DropIndex("dbo.SerialBidDetail", new[] { "BidId" });
            DropTable("dbo.SerialCategory");
            DropTable("dbo.SerialProduct");
            DropTable("dbo.Shopper");
            DropTable("dbo.SerialBid");
            DropTable("dbo.SerialBidDetail");
        }
    }
}
