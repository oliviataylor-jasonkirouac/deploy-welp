namespace deploy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedrating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "StarReview", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "StarReview", c => c.Short());
        }
    }
}
