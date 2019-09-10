namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNotNullInThumbnailLocationinMovieTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieThumbnailLocation", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieThumbnailLocation", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
