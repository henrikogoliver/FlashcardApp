using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? ParentCardsetId { get; set; }
        public Cardset ParentCardset { get; set; }
    }
}