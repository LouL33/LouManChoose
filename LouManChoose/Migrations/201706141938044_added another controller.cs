namespace LouManChoose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanothercontroller : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserFavRestaurants", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserFavRestaurants", "FavRestaurants_Id", "dbo.FavRestaurants");
            DropIndex("dbo.ApplicationUserFavRestaurants", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserFavRestaurants", new[] { "FavRestaurants_Id" });
            AddColumn("dbo.FavRestaurants", "GoogleId", c => c.String());
            AddColumn("dbo.FavRestaurants", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.FavRestaurants", "UserId");
            AddForeignKey("dbo.FavRestaurants", "UserId", "dbo.AspNetUsers", "Id");
            DropTable("dbo.ApplicationUserFavRestaurants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserFavRestaurants",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        FavRestaurants_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.FavRestaurants_Id });
            
            DropForeignKey("dbo.FavRestaurants", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FavRestaurants", new[] { "UserId" });
            DropColumn("dbo.FavRestaurants", "UserId");
            DropColumn("dbo.FavRestaurants", "GoogleId");
            CreateIndex("dbo.ApplicationUserFavRestaurants", "FavRestaurants_Id");
            CreateIndex("dbo.ApplicationUserFavRestaurants", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserFavRestaurants", "FavRestaurants_Id", "dbo.FavRestaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserFavRestaurants", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
