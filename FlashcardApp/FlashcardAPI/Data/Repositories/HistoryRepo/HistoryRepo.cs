using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FlashcardApp.API.Models;


namespace FlashcardAPI.Data.Repositories.HistoryRepo
{
    public class HistoryRepo : IHistoryRepo
    {
        private FlashcardDbContext _context;

        public HistoryRepo(FlashcardDbContext context)
        {
            _context = context;
        }

        public void AddHistory(History history)
        {
            _context.Histories.Add(history);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<History>> GetHistory(int cardSetId)
        {
            var historyEntries = await _context.Histories.Include(h => h.Flashcard.CardsetId == cardSetId).ToListAsync();
            return historyEntries;
        }
    }
}