using System.Collections.Generic;

namespace FlashcardApp.API.Models
{
    public class Cardset
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Flashcard> Flashcards { get; set; }
        public string UserId { get; set; }
    }
}