
using Microsoft.AspNetCore.Mvc;
using YgoData.DataCommand;
using YgoLogic.Factory.Creators;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellController : Controller
    {
        private readonly IDataCommand _ygoDataCommand;

        public SpellController(IDataCommand ygoDataCommand)
        {
            _ygoDataCommand = ygoDataCommand;
        }

        [HttpPost("SpellCard")]
        public IActionResult InsertSpellCard(CardDto card)
        {
            try
            {
                return Ok(new SpellCardCreator<int>(_ygoDataCommand, card).InsertData());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
