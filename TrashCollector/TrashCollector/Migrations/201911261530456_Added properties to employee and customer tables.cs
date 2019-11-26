namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpropertiestoemployeeandcustomertables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "start", c => c.String());
            AddColumn("dbo.CustomerModels", "end", c => c.String());
            AddColumn("dbo.CustomerModels", "ApplicationId", c => c.String(maxLength: 128));
            AddColumn("dbo.EmployeeModels", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerModels", "ApplicationId");
            CreateIndex("dbo.EmployeeModels", "ApplicationId");
            AddForeignKey("dbo.CustomerModels", "ApplicationId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EmployeeModels", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeModels", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerModels", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeModels", new[] { "ApplicationId" });
            DropIndex("dbo.CustomerModels", new[] { "ApplicationId" });
            DropColumn("dbo.EmployeeModels", "ApplicationId");
            DropColumn("dbo.CustomerModels", "ApplicationId");
            DropColumn("dbo.CustomerModels", "end");
            DropColumn("dbo.CustomerModels", "start");
        }
    }
}
