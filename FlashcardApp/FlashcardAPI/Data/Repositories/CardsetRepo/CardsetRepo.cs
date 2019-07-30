using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FlashcardApp.API.Models;

namespace FlashcardAPI.Data.Repositories.CardsetRepo
{
    public class CardsetRepo : ICardsetRepo
    {
        private FlashcardDbContext _context = new FlashcardDbContext();

        public void AddCardset(Cardset cardset)
        {
            _context.Cardsets.Add(cardset);
            _context.SaveChanges();
        }

        public bool DeleteCardset(int cardsetId)
        {
            var cardsetToRemove = _context.Cardsets.SingleOrDefault(c => c.Id == cardsetId);
            if (cardsetToRemove == null)
            {
                return false;
            }
            _context.Cardsets.Remove(cardsetToRemove);
            _context.SaveChangesAsync();
            return true;
        }

        public async Task<Cardset> GetCardset(int cardsetId)
        {
            var cardSet = await _context.Cardsets.SingleOrDefaultAsync(c => c.Id == cardsetId);
            return cardSet;
        }

        public async Task<IEnumerable<Cardset>> GetCardsets(string userId)
        {
            var cardSets = await _context.Cardsets.Where(c => c.UserId == userId).ToListAsync();
            return cardSets;
        }
    }
}