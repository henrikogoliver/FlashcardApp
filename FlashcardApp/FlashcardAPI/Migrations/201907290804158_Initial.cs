namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cardsets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flashcards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        CurrentStatus = c.Int(nullable: false),
                        CardsetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cardsets", t => t.CardsetId, cascadeDelete: true)
                .Index(t => t.CardsetId);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfStatus = c.DateTime(nullable: false),
                        StateOfFlashcard = c.Int(nullable: false),
                        FlashCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flashcards", t => t.FlashCardId, cascadeDelete: true)
                .Index(t => t.FlashCardId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateOfFlashcard = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "FlashCardId", "dbo.Flashcards");
            DropForeignKey("dbo.Flashcards", "CardsetId", "dbo.Cardsets");
            DropIndex("dbo.Histories", new[] { "FlashCardId" });
            DropIndex("dbo.Flashcards", new[] { "CardsetId" });
            DropTable("dbo.Status");
            DropTable("dbo.Histories");
            DropTable("dbo.Flashcards");
            DropTable("dbo.Cardsets");
        }
    }
}
