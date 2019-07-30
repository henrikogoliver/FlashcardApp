namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlashcardModelAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flashcards", "Question", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flashcards", "Question", c => c.String(maxLength: 2));
        }
    }
}
