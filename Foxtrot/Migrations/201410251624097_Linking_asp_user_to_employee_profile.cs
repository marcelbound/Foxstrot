namespace Foxtrot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Linking_asp_user_to_employee_profile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeProfiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Class = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Title = c.String(maxLength: 30),
                        Location = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Profile_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Profile_Id");
            AddForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.EmployeeProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.EmployeeProfiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Id" });
            DropColumn("dbo.AspNetUsers", "Profile_Id");
            DropTable("dbo.EmployeeProfiles");
        }
    }
}
