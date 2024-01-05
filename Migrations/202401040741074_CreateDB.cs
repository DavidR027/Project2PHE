namespace Project2PHE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Guid = c.String(nullable: false, maxLength: 36),
                        Role = c.String(maxLength: 50),
                        Password = c.String(maxLength: 20),
                        EmployeeNavigation_Guid = c.String(maxLength: 36),
                        VendorNavigation_Guid = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Employee", t => t.EmployeeNavigation_Guid)
                .ForeignKey("dbo.Vendor", t => t.VendorNavigation_Guid)
                .Index(t => t.EmployeeNavigation_Guid)
                .Index(t => t.VendorNavigation_Guid);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Guid = c.String(nullable: false, maxLength: 36),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Account", t => t.Guid)
                .Index(t => t.Guid);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        Guid = c.String(nullable: false, maxLength: 36),
                        CompanyName = c.String(maxLength: 50),
                        Address = c.String(maxLength: 255),
                        CompanyEmail = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 15),
                        Photo = c.Binary(),
                        CreateDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovedBy = c.String(nullable: false, maxLength: 36),
                        IsDeleted = c.Boolean(nullable: false),
                        BusinessField = c.String(maxLength: 255),
                        BusinessType = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Account", t => t.Guid)
                .ForeignKey("dbo.Employee", t => t.ApprovedBy, cascadeDelete: true)
                .Index(t => t.Guid)
                .Index(t => t.ApprovedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "VendorNavigation_Guid", "dbo.Vendor");
            DropForeignKey("dbo.Account", "EmployeeNavigation_Guid", "dbo.Employee");
            DropForeignKey("dbo.Vendor", "ApprovedBy", "dbo.Employee");
            DropForeignKey("dbo.Vendor", "Guid", "dbo.Account");
            DropForeignKey("dbo.Employee", "Guid", "dbo.Account");
            DropIndex("dbo.Vendor", new[] { "ApprovedBy" });
            DropIndex("dbo.Vendor", new[] { "Guid" });
            DropIndex("dbo.Employee", new[] { "Guid" });
            DropIndex("dbo.Account", new[] { "VendorNavigation_Guid" });
            DropIndex("dbo.Account", new[] { "EmployeeNavigation_Guid" });
            DropTable("dbo.Vendor");
            DropTable("dbo.Employee");
            DropTable("dbo.Account");
        }
    }
}
