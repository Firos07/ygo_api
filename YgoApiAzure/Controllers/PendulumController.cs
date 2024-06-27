
using Microsoft.AspNetCore.Mvc;
using YgoData.DataCommand.Interface;
using YgoLogic.Factory.Creators;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PendulumController : Controller
    {
        private readonly IDataCommand _ygoDataCommand;

        public PendulumController(IDataCommand ygoDataCommand)
        {
            _ygoDataCommand = ygoDataCommand;
        }

        [HttpPost("PendulumCard")]
        public IActionResult InsertPendulumCard(PendulumCardDto card)
        {
            try
            {
                return Ok(new PendulumCardCreator<int>(_ygoDataCommand, card).InsertData());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
