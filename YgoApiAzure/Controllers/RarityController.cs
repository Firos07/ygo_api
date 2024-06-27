
using Microsoft.AspNetCore.Mvc;
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryRarity.Creator;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RarityController : Controller
    {
        private readonly IRarityQuery _rarityQuery;

        public RarityController(IRarityQuery rarityQuery)
        {
            _rarityQuery = rarityQuery;
        }

        [HttpGet("RarityByCardAndExtensionGetList")]
        public IActionResult RarityByCardAndExtensionGetList(string CodeCard, int IdExtension)
        {
            try
            {
                return Ok(new RarityCreator(_rarityQuery).RarityByCardAndExtensionGetList(CodeCard, IdExtension));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
