using Microsoft.AspNetCore.Mvc;
using YgoData.Interface;
using YgoLogic;
using YgoLogic.Factory;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonsterController : Controller
    {
        private readonly ICardLogic _cardLogic;
        private readonly IYgoDataCommand _ygoDataCommand;

        public MonsterController(ICardLogic cardLogic, IYgoDataCommand ygoDataCommand)
        {
            _cardLogic = cardLogic;
            _ygoDataCommand = ygoDataCommand;
        }

        [HttpPost("MonsterCard")]
        public IActionResult InsertMonsterCard(MonsterCardDto card)
        {
            try
            {
                return Ok(_cardLogic.Insert(new MonsterCardCreator(_ygoDataCommand, card)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
