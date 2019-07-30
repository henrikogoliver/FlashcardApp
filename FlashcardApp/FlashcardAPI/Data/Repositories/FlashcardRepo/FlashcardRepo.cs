using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FlashcardApp.API.Models;

namespace FlashcardAPI.Data.Repositories
{
    public class FlashcardRepo : IFlashcardRepo
    {
        private FlashcardDbContext _context = new FlashcardDbContext();

        public void AddFlashcard(Flashcard flashcard)
        {
            _context.Flashcards.Add(flashcard);
            _context.SaveChangesAsync();
        }

        public void DeleteFlashcard(Flashcard flashcard)
        {
            _context.Flashcards.Remove(flashcard);
            _context.SaveChangesAsync();
        }

        public async Task<Flashcard> GetFlashcard(int flashcardId)
        {
            var flashcard = await _context.Flashcards.SingleOrDefaultAsync(f => f.Id == flashcardId);
            return flashcard;
        }

        public async Task<IEnumerable<Flashcard>> GetFlashcards(int cardsetId)
        {
            var flashcards = await _context.Flashcards.Where(f => f.CardsetId == cardsetId).ToListAsync();
            return flashcards;
        }
    }
}