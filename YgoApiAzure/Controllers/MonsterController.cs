
using Microsoft.AspNetCore.Mvc;
using YgoData.DataCommand;
using YgoLogic.Factory.Creators;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonsterController : Controller
    {
        private readonly IDataCommand _ygoDataCommand;

        public MonsterController(IDataCommand ygoDataCommand)
        {
            _ygoDataCommand = ygoDataCommand;
        }

        [HttpPost("MonsterCard")]
        public IActionResult InsertMonsterCard(MonsterCardDto card)
        {
            try
            {
                return Ok(new MonsterCardCreator(_ygoDataCommand, card).InsertData());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
