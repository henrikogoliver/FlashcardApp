using FlashcardAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FlashcardAPI.Models;
using FlashcardApp.API.Models;
using FlashcardAPI.Data.Repositories.HistoryRepo;

namespace FlashcardAPI.Controllers
{
    public class HistoryController : ApiController
    {
        private IHistoryRepo _historyRepo;

        public HistoryController(IHistoryRepo historyRepo)
        {
            _historyRepo = historyRepo;
        }

        [HttpGet]
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

        public HttpResponseMessage PostHistory([FromBody] History historyToAdd)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _historyRepo.AddHistory(historyToAdd);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
