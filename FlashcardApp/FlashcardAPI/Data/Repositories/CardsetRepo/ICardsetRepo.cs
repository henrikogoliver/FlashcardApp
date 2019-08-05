using FlashcardApp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashcardAPI.Data.Repositories.CardsetRepo
{
    public interface ICardsetRepo
    {
        void AddCardset(Cardset cardset);
        Task<bool> DeleteCardset(int cardsetId);
        Task<Cardset> GetCardset(int cardsetId);
        Task<IEnumerable<Cardset>> GetCardsets(string userId);
        Task CascadeDeleteCardset(int cardsetId);
        Task<bool> CardsetExists(int cardsetId); 
        //TODO - Update methods
    }
}
