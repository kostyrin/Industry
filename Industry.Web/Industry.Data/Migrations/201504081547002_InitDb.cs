namespace Industry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EntityGlobalId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        ActionTypeId = c.Int(nullable: false),
                        Mnemocode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionType", t => t.ActionTypeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ActionTypeId);
            
            CreateTable(
                "dbo.ActionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        CustomerCode = c.String(maxLength: 50),
                        CustomerDescr = c.String(maxLength: 250),
                        ManagerUserId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ManagerUserId)
                .Index(t => t.ManagerUserId);
            
            CreateTable(
                "dbo.ContactInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactInfoName = c.String(nullable: false, maxLength: 100),
                        ContactInfoDescr = c.String(),
                        IsBasic = c.Boolean(nullable: false),
                        CustomerId = c.Int(),
                        ContactId = c.Int(),
                        ContactInfoTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactInfoType", t => t.ContactInfoTypeId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.ContactInfoTypeId);
            
            CreateTable(
                "dbo.ContactInfoType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactInfoTypeName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerTypeName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contractor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractorName = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(),
                        Code = c.String(),
                        Descr = c.String(),
                        INN = c.String(),
                        KPP = c.String(),
                        OGRN = c.String(),
                        OKPO = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        PostAddress = c.String(),
                        RegistrationAddress = c.String(),
                        Account = c.String(),
                        Bank = c.String(),
                        BIK = c.String(),
                        CorrAccount = c.String(),
                        PrintInface = c.String(),
                        PrintOn = c.String(),
                        PrintPosition = c.String(),
                        PrintFullFIO = c.String(),
                        ContractorTypeId = c.Int(nullable: false),
                        ContractorFormId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Culture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocaleString",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        CultureId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Culture", t => t.CultureId)
                .Index(t => t.CultureId);
            
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
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shopper", t => t.ShopperId)
                .Index(t => t.ShopperId);
            
            CreateTable(
                "dbo.Shopper",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShopperName = c.String(),
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
                        GlobalId = c.Guid(nullable: false),
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
                        GlobalId = c.Guid(nullable: false),
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
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer_CustomerType",
                c => new
                    {
                        CustomerType_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerType_Id, t.Customer_Id })
                .ForeignKey("dbo.CustomerType", t => t.CustomerType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.CustomerType_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SerialProduct", "CategoryId", "dbo.SerialCategory");
            DropForeignKey("dbo.SerialBidDetail", "ProductId", "dbo.SerialProduct");
            DropForeignKey("dbo.SerialBid", "ShopperId", "dbo.Shopper");
            DropForeignKey("dbo.SerialBidDetail", "BidId", "dbo.SerialBid");
            DropForeignKey("dbo.LocaleString", "CultureId", "dbo.Culture");
            DropForeignKey("dbo.Contractor", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ActionLog", "UserId", "dbo.User");
            DropForeignKey("dbo.Customer", "ManagerUserId", "dbo.User");
            DropForeignKey("dbo.Customer_CustomerType", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Customer_CustomerType", "CustomerType_Id", "dbo.CustomerType");
            DropForeignKey("dbo.ContactInfo", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ContactInfo", "ContactInfoTypeId", "dbo.ContactInfoType");
            DropForeignKey("dbo.ActionLog", "ActionTypeId", "dbo.ActionType");
            DropIndex("dbo.Customer_CustomerType", new[] { "Customer_Id" });
            DropIndex("dbo.Customer_CustomerType", new[] { "CustomerType_Id" });
            DropIndex("dbo.SerialProduct", new[] { "CategoryId" });
            DropIndex("dbo.SerialBid", new[] { "ShopperId" });
            DropIndex("dbo.SerialBidDetail", new[] { "ProductId" });
            DropIndex("dbo.SerialBidDetail", new[] { "BidId" });
            DropIndex("dbo.LocaleString", new[] { "CultureId" });
            DropIndex("dbo.Contractor", new[] { "CustomerId" });
            DropIndex("dbo.ContactInfo", new[] { "ContactInfoTypeId" });
            DropIndex("dbo.ContactInfo", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "ManagerUserId" });
            DropIndex("dbo.ActionLog", new[] { "ActionTypeId" });
            DropIndex("dbo.ActionLog", new[] { "UserId" });
            DropTable("dbo.Customer_CustomerType");
            DropTable("dbo.SerialCategory");
            DropTable("dbo.SerialProduct");
            DropTable("dbo.Shopper");
            DropTable("dbo.SerialBid");
            DropTable("dbo.SerialBidDetail");
            DropTable("dbo.LocaleString");
            DropTable("dbo.Culture");
            DropTable("dbo.Contractor");
            DropTable("dbo.CustomerType");
            DropTable("dbo.ContactInfoType");
            DropTable("dbo.ContactInfo");
            DropTable("dbo.Customer");
            DropTable("dbo.User");
            DropTable("dbo.ActionType");
            DropTable("dbo.ActionLog");
        }
    }
}
