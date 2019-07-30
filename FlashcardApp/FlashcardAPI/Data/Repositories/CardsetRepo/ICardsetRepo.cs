using FlashcardApp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashcardAPI.Data.Repositories.CardsetRepo
{
    public interface ICardsetRepo
    {
        void AddCardset(Cardset cardset);
        bool DeleteCardset(int cardsetId);
        Task<Cardset> GetCardset(int cardsetId);
        Task<IEnumerable<Cardset>> GetCardsets(string userId);
        //TODO - Update methods
    }
}
