namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modeldataannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cardsets", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cardsets", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Flashcards", "Question", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flashcards", "Question", c => c.String());
            AlterColumn("dbo.Cardsets", "UserId", c => c.String());
            AlterColumn("dbo.Cardsets", "Title", c => c.String());
        }
    }
}
