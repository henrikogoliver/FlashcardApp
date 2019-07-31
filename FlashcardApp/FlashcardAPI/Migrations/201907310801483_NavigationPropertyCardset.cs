namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NavigationPropertyCardset : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cardsets", "ParentCardsetId");
            AddForeignKey("dbo.Cardsets", "ParentCardsetId", "dbo.Cardsets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cardsets", "ParentCardsetId", "dbo.Cardsets");
            DropIndex("dbo.Cardsets", new[] { "ParentCardsetId" });
        }
    }
}
