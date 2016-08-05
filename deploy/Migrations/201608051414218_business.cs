namespace deploy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class business : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusinessID = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(maxLength: 50),
                        BusinessTypeID = c.Int(nullable: false),
                        Address = c.String(maxLength: 100),
                        Hours = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        Menu = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BusinessID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.BusinessTypes", t => t.BusinessTypeID, cascadeDelete: true)
                .Index(t => t.BusinessTypeID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.BusinessTypes",
                c => new
                    {
                        BusinessTypeID = c.Int(nullable: false, identity: true),
                        BusinessTypeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BusinessTypeID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        BusinessID = c.Int(nullable: false),
                        StarReview = c.Short(),
                        TextReview = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessID, cascadeDelete: true)
                .Index(t => t.BusinessID)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "BusinessID", "dbo.Businesses");
            DropForeignKey("dbo.Ratings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Businesses", "BusinessTypeID", "dbo.BusinessTypes");
            DropForeignKey("dbo.Businesses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ratings", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Ratings", new[] { "BusinessID" });
            DropIndex("dbo.Businesses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Businesses", new[] { "BusinessTypeID" });
            DropTable("dbo.Ratings");
            DropTable("dbo.BusinessTypes");
            DropTable("dbo.Businesses");
        }
    }
}
