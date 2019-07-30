using FlashcardAPI.Data.Repositories;
using FlashcardApp.API.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FlashcardAPI.Controllers
{
    [RoutePrefix("api/flashcards")]
    public class FlashcardsController : ApiController
    {
        private IFlashcardRepo _flashcardRepo;

        public FlashcardsController(IFlashcardRepo flashcardRepo)
        {
            _flashcardRepo = flashcardRepo;
        }

        [HttpGet]
        [Route("{cardsetId=0}")]
        public async Task<IHttpActionResult> GetFlashcards(int cardsetId)
        {
            if (cardsetId == 0)
            {
                return BadRequest("Invalid cardset Id");
            }

            var flashcards = await _flashcardRepo.GetFlashcards(cardsetId);

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
        [Route("single/{flashcardId=0}")]
        public async Task<IHttpActionResult> GetFlashcard(int flashcardId)
        {
            if (flashcardId == 0)
            {
                return BadRequest("Invalid flashcard Id");
            }

            var flashcard = await _flashcardRepo.GetFlashcard(flashcardId);

            if (flashcard == null)
            {
                return NotFound();
            }

            return Ok(flashcard);
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage PostFlashcard([FromBody] Flashcard flashcardToAdd)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _flashcardRepo.AddFlashcard(flashcardToAdd);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("{flashcardId=0}")]
        public IHttpActionResult DeleteFlashcard(int flashcardId)
        {
            if (flashcardId == 0)
            {
                return BadRequest("Not a valid flashcardId");
            }

            var flashcardRemoved = _flashcardRepo.DeleteFlashcard(flashcardId);

            if (flashcardRemoved)
            {
                return Ok("Flashcard removed");
            }
            else
            {
                return BadRequest("Flashcard does not exist");
            }
        }
    }
}
