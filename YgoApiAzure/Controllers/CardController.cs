
using Microsoft.AspNetCore.Mvc;
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryCard.Creators;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly ICardQuery _cardQuery;

        public CardController(ICardQuery cardQuery)
        {
            _cardQuery = cardQuery;
        }

        [HttpGet("AllCardGetList")]
        public IActionResult AllCardGetList()
        {
            try
            {
                return Ok(new CardCreator(_cardQuery).AllCardGetList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
