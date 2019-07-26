using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashcardApp.API.Models
{
    public class History
    {
        public int Id{ get; set; }
        public DateTime DateOfStatus { get; set; }
        public int StateOfFlashcard { get; set; }
        public int FlashCardId { get; set; }
        public Flashcard Flashcard { get; set; }
    }
}