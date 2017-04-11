namespace Bluebox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReleaseDateToDateTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String());
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
