namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableParentCardsetId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cardsets", name: "Cardset_Id", newName: "ParentCardsetId");
            RenameIndex(table: "dbo.Cardsets", name: "IX_Cardset_Id", newName: "IX_ParentCardsetId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cardsets", name: "IX_ParentCardsetId", newName: "IX_Cardset_Id");
            RenameColumn(table: "dbo.Cardsets", name: "ParentCardsetId", newName: "Cardset_Id");
        }
    }
}
