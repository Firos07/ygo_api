using Microsoft.AspNetCore.Mvc;
using YgoData.Interface;
using YgoLogic;
using YgoLogic.Factory;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellController : Controller
    {
        private readonly ICardLogic _cardLogic;
        private readonly IYgoDataCommand _ygoDataCommand;

        public SpellController(ICardLogic cardLogic, IYgoDataCommand ygoDataCommand)
        {
            _cardLogic = cardLogic;
            _ygoDataCommand = ygoDataCommand;
        }

        [HttpPost("SpellCard")]
        public IActionResult InsertSpellCard(CardDto card)
        {
            try
            {
                return Ok(_cardLogic.Insert(new SpellCardCreator(_ygoDataCommand, card)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
