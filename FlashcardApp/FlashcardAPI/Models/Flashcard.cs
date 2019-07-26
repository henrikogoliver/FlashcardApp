using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashcardApp.API.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int CurrentStatus { get; set; }
        public int CardsetId { get; set; }
        public Cardset Cardset { get; set; }
    }
}