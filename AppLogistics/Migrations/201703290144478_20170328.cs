namespace AppLogistics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170328 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AFPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NIT = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Document = c.Long(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        BornDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        RetirementDate = c.DateTime(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        EmergencyContact = c.String(),
                        EmergencyContactPhone = c.String(),
                        Afp_Id = c.Int(),
                        BranchOffice_Id = c.Int(),
                        Eps_Id = c.Int(),
                        MaritalStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AFPs", t => t.Afp_Id)
                .ForeignKey("dbo.BranchOffices", t => t.BranchOffice_Id)
                .ForeignKey("dbo.EPS", t => t.Eps_Id)
                .ForeignKey("dbo.MaritalStatus", t => t.MaritalStatus_Id)
                .Index(t => t.Afp_Id)
                .Index(t => t.BranchOffice_Id)
                .Index(t => t.Eps_Id)
                .Index(t => t.MaritalStatus_Id);
            
            CreateTable(
                "dbo.BranchOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.EPS", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EPS", "NIT", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "MaritalStatus_Id", "dbo.MaritalStatus");
            DropForeignKey("dbo.Employees", "Eps_Id", "dbo.EPS");
            DropForeignKey("dbo.Employees", "BranchOffice_Id", "dbo.BranchOffices");
            DropForeignKey("dbo.Employees", "Afp_Id", "dbo.AFPs");
            DropIndex("dbo.Employees", new[] { "MaritalStatus_Id" });
            DropIndex("dbo.Employees", new[] { "Eps_Id" });
            DropIndex("dbo.Employees", new[] { "BranchOffice_Id" });
            DropIndex("dbo.Employees", new[] { "Afp_Id" });
            AlterColumn("dbo.EPS", "NIT", c => c.String());
            AlterColumn("dbo.EPS", "Name", c => c.String());
            DropTable("dbo.MaritalStatus");
            DropTable("dbo.BranchOffices");
            DropTable("dbo.Employees");
            DropTable("dbo.AFPs");
        }
    }
}
