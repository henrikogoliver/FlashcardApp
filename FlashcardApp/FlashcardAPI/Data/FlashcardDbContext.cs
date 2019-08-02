using FlashcardApp.API.Models;
using System.Data.Entity;

namespace FlashcardAPI.Data
{
    public class FlashcardDbContext : DbContext
    {
        public DbSet<Cardset> Cardsets { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cardset>()
                .HasOptional(c => c.ParentCardset)
                .WithMany()
                .HasForeignKey(c => c.ParentCardsetId);
        }
    }
}