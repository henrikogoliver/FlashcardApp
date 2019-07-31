namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentCardsetId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cardsets", "ParentCardsetId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cardsets", "ParentCardsetId");
        }
    }
}
