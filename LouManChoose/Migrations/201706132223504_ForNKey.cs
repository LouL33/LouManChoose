namespace LouManChoose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForNKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavRestaurants", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FavRestaurants", new[] { "UserId" });
            CreateTable(
                "dbo.ApplicationUserFavRestaurants",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        FavRestaurants_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.FavRestaurants_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.FavRestaurants", t => t.FavRestaurants_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.FavRestaurants_Id);
            
            AlterColumn("dbo.FavRestaurants", "Faveorited", c => c.Boolean());
            DropColumn("dbo.FavRestaurants", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FavRestaurants", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ApplicationUserFavRestaurants", "FavRestaurants_Id", "dbo.FavRestaurants");
            DropForeignKey("dbo.ApplicationUserFavRestaurants", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserFavRestaurants", new[] { "FavRestaurants_Id" });
            DropIndex("dbo.ApplicationUserFavRestaurants", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.FavRestaurants", "Faveorited", c => c.String());
            DropTable("dbo.ApplicationUserFavRestaurants");
            CreateIndex("dbo.FavRestaurants", "UserId");
            AddForeignKey("dbo.FavRestaurants", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
