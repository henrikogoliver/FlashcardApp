using FlashcardApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlashcardAPI.Controllers
{
    public class FlashcardsController : ApiController
    {
        static List<Flashcard> flashcards = new List<Flashcard>()
        {
            new Flashcard {Id = 1, Question="Test Question 1", Answer="Test Answer 1"},
            new Flashcard {Id = 2, Question="Test Question 2", Answer="Test Answer 2"},
            new Flashcard {Id = 3, Question="Test Question 3", Answer="Test Answer 3"},
        };

        public IEnumerable<Flashcard> GetFlashcards()
        {
            return flashcards;
        }

        public IHttpActionResult GetFlashcard(int id)
        {
            return Ok(flashcards.Find(f => f.Id == id));
        }

        public IHttpActionResult PostFlashcard([FromBody] Flashcard flashcardToAdd)
        {
            if (flashcardToAdd == null)
            {
                return BadRequest("Not a valid flashcard");
            }
            Console.WriteLine(flashcardToAdd.Answer);
            flashcards.Add(flashcardToAdd);
            return Ok();
        }
    }
}
