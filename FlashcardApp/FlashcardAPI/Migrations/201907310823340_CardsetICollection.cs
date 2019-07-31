namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardsetICollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cardsets", "Cardset_Id", c => c.Int());
            CreateIndex("dbo.Cardsets", "Cardset_Id");
            AddForeignKey("dbo.Cardsets", "Cardset_Id", "dbo.Cardsets", "Id");
            DropColumn("dbo.Cardsets", "ParentCardsetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cardsets", "ParentCardsetId", c => c.Int());
            DropForeignKey("dbo.Cardsets", "Cardset_Id", "dbo.Cardsets");
            DropIndex("dbo.Cardsets", new[] { "Cardset_Id" });
            DropColumn("dbo.Cardsets", "Cardset_Id");
        }
    }
}
