using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FlashcardApp.API.Models;
using FlashcardAPI.Data.Repositories.HistoryRepo;

namespace FlashcardAPI.Controllers
{
    [RoutePrefix("api/histories")]
    public class HistoryController : ApiController
    {
        private IHistoryRepo _historyRepo;

        public HistoryController(IHistoryRepo historyRepo)
        {
            _historyRepo = historyRepo;
        }

        [HttpGet]
        [Route("cardset/{cardsetId=0}")]
        public async Task<IHttpActionResult> GetHistory(int cardsetId)
        {
            if (cardsetId == 0)
            {
                return BadRequest("You need to provide a valid cardset.");
            }

            var historyEntries = await _historyRepo.GetHistory(cardsetId);
            if (historyEntries.Count() == 0)
            {
                return NotFound();
            }

            return Ok(historyEntries);
        }

        [HttpGet]
        [Route("flashcard/{flashcardId=0}")]
        public async Task<IHttpActionResult> GetHistoryForFlashcard(int flashcardId)
        {
            if (flashcardId == 0)
            {
                return BadRequest("Invalid flashcardId");
            }

            var historyForFlashcard = await _historyRepo.GetHistoryForFlashcard(flashcardId);
            if (historyForFlashcard == null)
            {
                return NotFound();
            }

            return Ok(historyForFlashcard);
        }

        [HttpPost]
        [Route("single")]
        public HttpResponseMessage PostHistory([FromBody] History historyToAdd)
        {
            historyToAdd.DateOfStatus = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _historyRepo.AddHistory(historyToAdd);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("multiple")]
        public HttpResponseMessage PostHistories([FromBody] ICollection<History> histories)
        {
            foreach(var history in histories)
            {
                history.DateOfStatus = DateTime.Now;
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _historyRepo.AddHistories(histories);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }


    }
}
