namespace Foxtrot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_search_text_column_to_employee_profile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeProfiles", "SearchText", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeProfiles", "SearchText");
        }
    }
}
