namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnsMovieThumbnailMovieImageLocAndPathToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieThumbnailLocation", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Movies", "MovieThumbnailName", c => c.String(maxLength: 255));
            AddColumn("dbo.Movies", "MovieImageLocation", c => c.String(maxLength: 255));
            AddColumn("dbo.Movies", "MovieImageName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieImageName");
            DropColumn("dbo.Movies", "MovieImageLocation");
            DropColumn("dbo.Movies", "MovieThumbnailName");
            DropColumn("dbo.Movies", "MovieThumbnailLocation");
        }
    }
}
