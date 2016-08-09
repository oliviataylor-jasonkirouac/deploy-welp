namespace deploy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StarReviewID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "StarReviewID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "StarReviewID");
        }
    }
}
