using FlashcardApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardAPI.Data.Repositories
{
    public interface IFlashcardRepo
    {
        void AddFlashcard(Flashcard flashcard);
        bool DeleteFlashcard(int flashcardId);
        Task<Flashcard> GetFlashcard(int flashcardId);
        Task<IEnumerable<Flashcard>> GetFlashcards(int cardSetId);
        //TODO - Update methods
    }
}
