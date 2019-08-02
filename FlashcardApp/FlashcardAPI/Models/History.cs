using System;

namespace FlashcardApp.API.Models
{
    public class History
    {
        public int Id{ get; set; }
        public DateTime DateOfStatus { get; set; }
        public int FlashcardStatusId { get; set; }
        public Status FlashcardStatus { get; set; }
        public int FlashCardId { get; set; }
        public Flashcard Flashcard { get; set; }
    }
}