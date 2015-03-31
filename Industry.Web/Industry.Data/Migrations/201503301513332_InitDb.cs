namespace Industry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(maxLength: 50),
                        Descr = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Website = c.String(maxLength: 50),
                        CustomerTypeId = c.Int(nullable: false),
                        Province = c.String(maxLength: 150),
                        ResponsibleUserId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedId = c.Int(nullable: false),
                        ModifiedId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerType", t => t.CustomerTypeId)
                .ForeignKey("dbo.User", t => t.ResponsibleUserId)
                .Index(t => t.CustomerTypeId)
                .Index(t => t.ResponsibleUserId);
            
            CreateTable(
                "dbo.CustomerType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Image = c.Binary(),
                        DealerId = c.Int(),
                        DepartmentId = c.Int(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Boolean(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.Double(),
                        ContactNo = c.Double(),
                        GlobalUserId = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedId = c.Int(nullable: false),
                        ModifiedId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SerialBidDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BidId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Short(nullable: false),
                        Discount = c.Single(nullable: false),
                        IsActive = c.Boolean(nullable: false),
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
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
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
                        CreatedId = c.Int(nullable: false),
                        ModifiedId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
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
                        CreatedId = c.Int(nullable: false),
                        ModifiedId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
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
                        CreatedId = c.Int(nullable: false),
                        ModifiedId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SerialProduct", "CategoryId", "dbo.SerialCategory");
            DropForeignKey("dbo.SerialBidDetail", "ProductId", "dbo.SerialProduct");
            DropForeignKey("dbo.SerialBid", "ShopperId", "dbo.Shopper");
            DropForeignKey("dbo.SerialBidDetail", "BidId", "dbo.SerialBid");
            DropForeignKey("dbo.Customer", "ResponsibleUserId", "dbo.User");
            DropForeignKey("dbo.Customer", "CustomerTypeId", "dbo.CustomerType");
            DropIndex("dbo.SerialProduct", new[] { "CategoryId" });
            DropIndex("dbo.SerialBid", new[] { "ShopperId" });
            DropIndex("dbo.SerialBidDetail", new[] { "ProductId" });
            DropIndex("dbo.SerialBidDetail", new[] { "BidId" });
            DropIndex("dbo.Customer", new[] { "ResponsibleUserId" });
            DropIndex("dbo.Customer", new[] { "CustomerTypeId" });
            DropTable("dbo.SerialCategory");
            DropTable("dbo.SerialProduct");
            DropTable("dbo.Shopper");
            DropTable("dbo.SerialBid");
            DropTable("dbo.SerialBidDetail");
            DropTable("dbo.User");
            DropTable("dbo.CustomerType");
            DropTable("dbo.Customer");
        }
    }
}
