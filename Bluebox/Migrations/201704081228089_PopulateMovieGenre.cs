namespace Bluebox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, StockNum) VALUES ('Hangover', 'Comedy', '11/06/2009', '4/8/2017', 10)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, StockNum) VALUES ('Die Hard', 'Action', '07/20/1988', '4/8/2017', 15)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, StockNum) VALUES ('The Terminator', 'Action', '10/26/1984', '4/8/2017', 10)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, StockNum) VALUES ('Toy Story', 'Family', '11/22/1995', '4/8/2017', 20)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, StockNum) VALUES ('Titanic', 'Romance', '12/19/1997', '4/8/2017', 5)");

        }
        
        public override void Down()
        {
        }
    }
}
