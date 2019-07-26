using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashcardApp.API.Models
{
    public class Cardset
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Flashcard> Flashcards { get; set; }
    }
}