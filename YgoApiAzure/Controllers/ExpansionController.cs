
using Microsoft.AspNetCore.Mvc;
using YgoData.DataQuery.Interface;
using YgoLogic.Factory.Creators;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    public class ExpansionController : Controller
    {
        private readonly IDataQuery<ExpansionDto> _cardData;

        public ExpansionController(IDataQuery<ExpansionDto> cardData)
        {
            _cardData = cardData;
        }

        [HttpGet("ExpansionListbyCodeCard")]
        public IActionResult ExpansionbyCodeCardGetl(string CodeCard)
        {
            try
            {
                return Ok(new ExpansionCreator(_cardData).DataByCodeGetList(CodeCard));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
