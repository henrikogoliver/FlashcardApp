using FlashcardApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardAPI.Data.Repositories.HistoryRepo
{
    public interface IHistoryRepo
    {
        Task<IEnumerable<History>> GetHistory(int cardSetId);
        void AddHistory(History history);
    }
}
