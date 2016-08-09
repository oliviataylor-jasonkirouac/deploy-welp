namespace deploy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ratings", "StarReviewID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "StarReviewID", c => c.Int(nullable: false));
        }
    }
}
