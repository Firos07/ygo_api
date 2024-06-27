
using Microsoft.AspNetCore.Mvc;
using YgoData.DataCommand.Interface;
using YgoLogic.Factory.Creators;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrapController : Controller
    {
        private readonly IDataCommand _ygoDataCommand;

        public TrapController(IDataCommand ygoDataCommand)
        {
            _ygoDataCommand = ygoDataCommand;
        }

        [HttpPost("TrapCard")]
        public IActionResult InsertTrapCard(CardDto card)
        {
            try
            {
                return Ok(new TrapCardCreator<int>(_ygoDataCommand, card).InsertData());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
