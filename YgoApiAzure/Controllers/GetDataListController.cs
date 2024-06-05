
using Microsoft.AspNetCore.Mvc;
using YgoLogic.Interfaces;

namespace YgoApiAzure.Controllers
{
    public class GetDataListController : Controller
    {
        private readonly IDataCardGetList _cardLogic;

        public GetDataListController(IDataCardGetList cardLogic)
        {
            _cardLogic = cardLogic;
        }

        [HttpGet("ExpansionListbyCodeCard")]
        public IActionResult ExpansionbyCodeCardGetl(string CodeCard)
        {
            try
            {
                return Ok(_cardLogic.ExpansionbyCodeCardGetl(CodeCard));                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("RarityListbyCodeCard")]
        public IActionResult RaritybyCodeCardGetl(string CodeCard, int IdExtension)
        {
            try
            {
                return Ok(_cardLogic.RaritybyCodeCardGetl(CodeCard, IdExtension));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
