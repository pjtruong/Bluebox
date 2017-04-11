namespace Bluebox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET Name = 'Action' WHERE Id = '1'");
            Sql("UPDATE Genres SET Name = 'Thriller' WHERE Id = '2'");
            Sql("UPDATE Genres SET Name = 'Family' WHERE Id = '3'");
            Sql("UPDATE Genres SET Name = 'Romance' WHERE Id = '4'");
            Sql("UPDATE Genres SET Name = 'Comedy' WHERE Id = '5'");

        }
        
        public override void Down()
        {
        }
    }
}
