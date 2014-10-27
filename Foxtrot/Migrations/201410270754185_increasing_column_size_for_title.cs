namespace Foxtrot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class increasing_column_size_for_title : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeProfiles", "Title", c => c.String(maxLength: 75));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeProfiles", "Title", c => c.String(maxLength: 30));
        }
    }
}
