using System.ComponentModel.DataAnnotations;

namespace FlashcardApp.API.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        [Required]
        public int CardsetId { get; set; }
        public Cardset Cardset { get; set; }
    }
}