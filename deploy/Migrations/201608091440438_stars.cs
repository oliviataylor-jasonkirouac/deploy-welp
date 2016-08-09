namespace deploy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Stars", c => c.String());
            DropColumn("dbo.Ratings", "Stars");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Stars", c => c.String());
            DropColumn("dbo.Ratings", "Stars");
        }
    }
}
