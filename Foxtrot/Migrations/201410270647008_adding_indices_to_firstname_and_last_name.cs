namespace Foxtrot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_indices_to_firstname_and_last_name : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EmployeeProfiles", "FirstName");
            CreateIndex("dbo.EmployeeProfiles", "LastName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EmployeeProfiles", new[] { "LastName" });
            DropIndex("dbo.EmployeeProfiles", new[] { "FirstName" });
        }
    }
}
