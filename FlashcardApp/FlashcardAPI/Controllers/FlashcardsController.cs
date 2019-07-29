using FlashcardAPI.Data;
using FlashcardAPI.Data.Repositories.FlashcardRepo;
using FlashcardApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FlashcardAPI.Controllers
{
    public class FlashcardsController : ApiController
    {
        private FlashcardRepo _repo = new FlashcardRepo();

        [HttpGet]
        [Route("api/flashcards/{cardsetId=0}")]
        public async Task<IHttpActionResult> GetFlashcards(int cardsetId)
        {
            if (cardsetId == 0)
            {
                return BadRequest("Invalid cardset Id");
            }

            var flashcards = await _repo.GetFlashcards(cardsetId);

            if (flashcards == null || flashcards.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(flashcards);
            }
        }

        [HttpGet]
        [Route("api/flashcard/{flashcardId=0}")]
        public async Task<IHttpActionResult> GetFlashcard(int flashcardId)
        {
            if (flashcardId == 0)
            {
                return BadRequest("Invalid flashcard Id");
            }

            return Ok(await _repo.GetFlashcard(flashcardId));
        }

        [HttpPost]
        public IHttpActionResult PostFlashcard([FromBody] Flashcard flashcardToAdd)
        {
            if (flashcardToAdd == null)
            {
                return BadRequest("Not a valid flashcard");
            }

            _repo.AddFlashcard(flashcardToAdd);

            return StatusCode(HttpStatusCode.Created);
        }
    }
}
