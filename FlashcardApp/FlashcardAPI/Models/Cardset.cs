using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlashcardApp.API.Models
{
    public class Cardset
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public ICollection<Flashcard> Flashcards { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}