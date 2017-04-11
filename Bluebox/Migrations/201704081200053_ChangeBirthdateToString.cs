namespace Bluebox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBirthdateToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
    }
}
