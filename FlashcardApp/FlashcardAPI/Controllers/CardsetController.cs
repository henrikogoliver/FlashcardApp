using FlashcardAPI.Data.Repositories.CardsetRepo;
using FlashcardApp.API.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FlashcardAPI.Controllers
{
    [RoutePrefix("api/cardsets")]
    public class CardsetController : ApiController
    {
        private readonly ICardsetRepo _cardsetRepo;

        public CardsetController(ICardsetRepo cardsetRepo)
        {
            _cardsetRepo = cardsetRepo;
        }

        [HttpGet]
        [Route]
        public async Task<IHttpActionResult> GetCardsets()
        {
            var userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return BadRequest("Invalid user Id");
            }

            var cardsets = await _cardsetRepo.GetCardsets(userId);

            if (cardsets == null || cardsets.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cardsets);
            }
        }

        [HttpGet]
        [Route("single/{cardsetId=0}")]
        public async Task<IHttpActionResult> GetCardset(int cardsetId)
        {
            if (cardsetId == 0)
            {
                return BadRequest("Invalid cardset Id");
            }

            var cardset = await _cardsetRepo.GetCardset(cardsetId);

            if (cardset == null)
            {
                return NotFound();
            }

            return Ok(cardset);
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage PostCardset([FromBody] Cardset cardsetToAdd)
        {
            var userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                cardsetToAdd.UserId = userId;
            }


            ModelState.Remove("cardsetToAdd.UserId");

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _cardsetRepo.AddCardset(cardsetToAdd);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("{cardsetId=0}")]
        public async Task<IHttpActionResult> DeleteCardset(int cardsetId)
        {
            if (cardsetId == 0)
            {
                return BadRequest("Not a valid cardsetId");
            }

            var cardsetRemoved = await _cardsetRepo.DeleteCardset(cardsetId);

            if (cardsetRemoved)
            {
                return Ok("Cardset removed");
            }
            else
            {
                return BadRequest("Cardset does not exist");
            }
        }
    }
}
