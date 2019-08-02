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
        private FlashcardDbContext _context;

        public CardsetRepo(FlashcardDbContext context)
        {
            _context = context;
        }

        public void AddCardset(Cardset cardset)
        {
            _context.Cardsets.Add(cardset);
            _context.SaveChanges();
        }

        public async Task<bool> DeleteCardset(int cardsetId)
        {
            var cardsetToRemove = _context.Cardsets.SingleOrDefault(c => c.Id == cardsetId);
            if (cardsetToRemove == null)
            {
                return false;
            }

            await CascadeDeleteCardset(cardsetToRemove.Id);

            _context.Cardsets.Remove(cardsetToRemove);
            _context.SaveChanges();
            return true;
        }

        public async Task CascadeDeleteCardset(int cardsetId)
        {
            var children = await _context.Cardsets.Where(c => c.ParentCardsetId == cardsetId).ToListAsync();
            foreach (var child in children)
            {
                await CascadeDeleteCardset(child.Id);
                _context.Cardsets.Remove(child);
            }
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