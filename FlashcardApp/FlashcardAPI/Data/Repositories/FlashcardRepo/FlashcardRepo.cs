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
        private FlashcardDbContext _context;

        public FlashcardRepo(FlashcardDbContext context)
        {
            _context = context;
        }

        public void AddFlashcard(Flashcard flashcard)
        {
            _context.Flashcards.Add(flashcard);
            _context.SaveChanges();
        }

        public bool DeleteFlashcard(int flashcardId)
        {
            var flashcardToRemove = _context.Flashcards.SingleOrDefault(f => f.Id == flashcardId);
            if (flashcardToRemove == null)
            {
                return false;
            }
            _context.Flashcards.Remove(flashcardToRemove);
            _context.SaveChangesAsync();
            return true;
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