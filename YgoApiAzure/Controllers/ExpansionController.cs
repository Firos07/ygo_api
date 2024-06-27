
using Microsoft.AspNetCore.Mvc;
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryExpansion.Creator;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpansionController : Controller
    {
        private readonly IExpansionQuery _cardData;

        public ExpansionController(IExpansionQuery cardData)
        {
            _cardData = cardData;
        }

        [HttpGet("ExpansionListbyCodeCard")]
        public IActionResult ExpansionbyCodeCardGetl(string CodeCard)
        {
            try
            {
                return Ok(new ExpansionCreator(_cardData).DataByCodeCardGetList(CodeCard));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
