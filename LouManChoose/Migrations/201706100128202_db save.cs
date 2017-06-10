namespace LouManChoose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsave : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavRestaurants", "Faveorited", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FavRestaurants", "Faveorited");
        }
    }
}
