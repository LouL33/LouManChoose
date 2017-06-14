namespace LouManChoose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlogic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FavRestaurants", "Faveorited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FavRestaurants", "Faveorited", c => c.Boolean());
        }
    }
}
