namespace FlashcardAPI.Migrations
{
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
                        Title = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(nullable: false),
                        ParentCardsetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cardsets", t => t.ParentCardsetId)
                .Index(t => t.ParentCardsetId);
            
            CreateTable(
                "dbo.Flashcards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
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
                        FlashcardStatusId = c.Int(nullable: false),
                        FlashCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flashcards", t => t.FlashCardId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.FlashcardStatusId, cascadeDelete: true)
                .Index(t => t.FlashcardStatusId)
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
            DropForeignKey("dbo.Histories", "FlashcardStatusId", "dbo.Status");
            DropForeignKey("dbo.Histories", "FlashCardId", "dbo.Flashcards");
            DropForeignKey("dbo.Cardsets", "ParentCardsetId", "dbo.Cardsets");
            DropForeignKey("dbo.Flashcards", "CardsetId", "dbo.Cardsets");
            DropIndex("dbo.Histories", new[] { "FlashCardId" });
            DropIndex("dbo.Histories", new[] { "FlashcardStatusId" });
            DropIndex("dbo.Flashcards", new[] { "CardsetId" });
            DropIndex("dbo.Cardsets", new[] { "ParentCardsetId" });
            DropTable("dbo.Status");
            DropTable("dbo.Histories");
            DropTable("dbo.Flashcards");
            DropTable("dbo.Cardsets");
        }
    }
}
