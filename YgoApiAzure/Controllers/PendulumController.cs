using Microsoft.AspNetCore.Mvc;
using YgoData.Interface;
using YgoLogic;
using YgoLogic.Factory;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PendulumController : Controller
    {
        private readonly ICardLogic _cardLogic;
        private readonly IYgoDataCommand _ygoDataCommand;

        public PendulumController(ICardLogic cardLogic, IYgoDataCommand ygoDataCommand)
        {
            _cardLogic = cardLogic;
            _ygoDataCommand = ygoDataCommand;
        }

        [HttpPost("PendulumCard")]
        public IActionResult InsertPendulumCard(PendulumCardDto card)
        {
            try
            {
                return Ok(_cardLogic.Insert(new PendulumCardCreator(_ygoDataCommand, card)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
