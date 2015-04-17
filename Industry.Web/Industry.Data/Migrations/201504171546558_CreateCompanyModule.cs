namespace Industry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCompanyModule : DbMigration
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
                        Name = c.String(nullable: false, maxLength: 150),
                        Code = c.String(maxLength: 50),
                        Descr = c.String(maxLength: 250),
                        ManagerUserId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ManagerUserId)
                .Index(t => t.ManagerUserId);
            
            CreateTable(
                "dbo.CompanyType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contractor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        FullName = c.String(maxLength: 250),
                        Code = c.String(maxLength: 50),
                        Descr = c.String(maxLength: 150),
                        IsRussainAdress = c.Boolean(nullable: false),
                        RegistrationAddress = c.String(maxLength: 250),
                        PostAddress = c.String(maxLength: 250),
                        Passport = c.String(maxLength: 250),
                        INN = c.String(maxLength: 50),
                        KPP = c.String(maxLength: 50),
                        OGRN = c.String(maxLength: 50),
                        OKPO = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 150),
                        Email = c.String(maxLength: 150),
                        PrintInface = c.String(maxLength: 150),
                        PrintOn = c.String(maxLength: 150),
                        PrintPosition = c.String(maxLength: 150),
                        PrintFullFIO = c.String(maxLength: 150),
                        ContractorTypeId = c.Int(nullable: false),
                        ContractorFormId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractorForm", t => t.ContractorFormId)
                .ForeignKey("dbo.ContractorType", t => t.ContractorTypeId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.ContractorTypeId)
                .Index(t => t.ContractorFormId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ContractorForm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractorType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Descr = c.String(maxLength: 150),
                        IsBasic = c.Boolean(nullable: false),
                        CustomerId = c.Int(),
                        ContactId = c.Int(),
                        ContactInfoTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId)
                .ForeignKey("dbo.ContactInfoType", t => t.ContactInfoTypeId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.ContactId)
                .Index(t => t.ContactInfoTypeId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        BirthDate = c.DateTime(),
                        Position = c.String(maxLength: 100),
                        Image = c.Binary(),
                        Descr = c.String(maxLength: 150),
                        CustomerId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        GlobalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
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
                "dbo.CustomerPoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Address = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 150),
                        Email = c.String(maxLength: 150),
                        IsDelivery = c.Boolean(nullable: false),
                        Descr = c.String(maxLength: 250),
                        CustomerId = c.Int(nullable: false),
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
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Level = c.String(),
                        Message = c.String(),
                        Exception = c.String(),
                        Ticket = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
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
                        GlobalId = c.Guid(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
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
                "dbo.Contractor_CompanyType",
                c => new
                    {
                        Contractor_Id = c.Int(nullable: false),
                        CompanyType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contractor_Id, t.CompanyType_Id })
                .ForeignKey("dbo.Contractor", t => t.Contractor_Id, cascadeDelete: true)
                .ForeignKey("dbo.CompanyType", t => t.CompanyType_Id, cascadeDelete: true)
                .Index(t => t.Contractor_Id)
                .Index(t => t.CompanyType_Id);
            
            CreateTable(
                "dbo.Customer_CompanyType",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        CompanyType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.CompanyType_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.CompanyType", t => t.CompanyType_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.CompanyType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SerialProduct", "CategoryId", "dbo.SerialCategory");
            DropForeignKey("dbo.SerialBidDetail", "ProductId", "dbo.SerialProduct");
            DropForeignKey("dbo.SerialBid", "ShopperId", "dbo.Shopper");
            DropForeignKey("dbo.SerialBidDetail", "BidId", "dbo.SerialBid");
            DropForeignKey("dbo.LocaleString", "CultureId", "dbo.Culture");
            DropForeignKey("dbo.ActionLog", "UserId", "dbo.User");
            DropForeignKey("dbo.Customer", "ManagerUserId", "dbo.User");
            DropForeignKey("dbo.CustomerPoint", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ContactInfo", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ContactInfo", "ContactInfoTypeId", "dbo.ContactInfoType");
            DropForeignKey("dbo.Contact", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ContactInfo", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Customer_CompanyType", "CompanyType_Id", "dbo.CompanyType");
            DropForeignKey("dbo.Customer_CompanyType", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Contractor", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Contractor", "ContractorTypeId", "dbo.ContractorType");
            DropForeignKey("dbo.Contractor", "ContractorFormId", "dbo.ContractorForm");
            DropForeignKey("dbo.Contractor_CompanyType", "CompanyType_Id", "dbo.CompanyType");
            DropForeignKey("dbo.Contractor_CompanyType", "Contractor_Id", "dbo.Contractor");
            DropForeignKey("dbo.ActionLog", "ActionTypeId", "dbo.ActionType");
            DropIndex("dbo.Customer_CompanyType", new[] { "CompanyType_Id" });
            DropIndex("dbo.Customer_CompanyType", new[] { "Customer_Id" });
            DropIndex("dbo.Contractor_CompanyType", new[] { "CompanyType_Id" });
            DropIndex("dbo.Contractor_CompanyType", new[] { "Contractor_Id" });
            DropIndex("dbo.SerialProduct", new[] { "CategoryId" });
            DropIndex("dbo.SerialBid", new[] { "ShopperId" });
            DropIndex("dbo.SerialBidDetail", new[] { "ProductId" });
            DropIndex("dbo.SerialBidDetail", new[] { "BidId" });
            DropIndex("dbo.LocaleString", new[] { "CultureId" });
            DropIndex("dbo.CustomerPoint", new[] { "CustomerId" });
            DropIndex("dbo.Contact", new[] { "CustomerId" });
            DropIndex("dbo.ContactInfo", new[] { "ContactInfoTypeId" });
            DropIndex("dbo.ContactInfo", new[] { "ContactId" });
            DropIndex("dbo.ContactInfo", new[] { "CustomerId" });
            DropIndex("dbo.Contractor", new[] { "CustomerId" });
            DropIndex("dbo.Contractor", new[] { "ContractorFormId" });
            DropIndex("dbo.Contractor", new[] { "ContractorTypeId" });
            DropIndex("dbo.Customer", new[] { "ManagerUserId" });
            DropIndex("dbo.ActionLog", new[] { "ActionTypeId" });
            DropIndex("dbo.ActionLog", new[] { "UserId" });
            DropTable("dbo.Customer_CompanyType");
            DropTable("dbo.Contractor_CompanyType");
            DropTable("dbo.SerialCategory");
            DropTable("dbo.SerialProduct");
            DropTable("dbo.Shopper");
            DropTable("dbo.SerialBid");
            DropTable("dbo.SerialBidDetail");
            DropTable("dbo.Log");
            DropTable("dbo.LocaleString");
            DropTable("dbo.Culture");
            DropTable("dbo.CustomerPoint");
            DropTable("dbo.ContactInfoType");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactInfo");
            DropTable("dbo.ContractorType");
            DropTable("dbo.ContractorForm");
            DropTable("dbo.Contractor");
            DropTable("dbo.CompanyType");
            DropTable("dbo.Customer");
            DropTable("dbo.User");
            DropTable("dbo.ActionType");
            DropTable("dbo.ActionLog");
        }
    }
}
