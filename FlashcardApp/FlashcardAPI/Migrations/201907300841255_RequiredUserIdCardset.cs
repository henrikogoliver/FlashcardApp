namespace FlashcardAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredUserIdCardset : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cardsets", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cardsets", "UserId", c => c.String());
        }
    }
}
