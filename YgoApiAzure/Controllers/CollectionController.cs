
using Microsoft.AspNetCore.Mvc;
using YgoData.DataCommand.Interface;
using YgoLogic.FactoryCollection.Creator;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectionController : Controller
    {
        private readonly ICollectionCommand _collectionCommand;
        private readonly ICardInCollectionCommand _CardInCollectionCommand;

        public CollectionController(ICollectionCommand collectionCommand, ICardInCollectionCommand cardInCollectionCommand)
        {
            _collectionCommand = collectionCommand;
            _CardInCollectionCommand = cardInCollectionCommand;
        }

        [HttpPost("InsertCollection")]
        public IActionResult InsertCollection(CollectionDto collection, int IdUser)
        {
            try
            {
                return Ok(new CollectionCreator(_collectionCommand, _CardInCollectionCommand).InsertCollection(collection, IdUser));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("InsertCardInCollection")]
        public IActionResult InsertCardInCollection(CardInCollectionDto cardInCollection, int IdCollection)
        {
            try
            {
                return Ok(new CollectionCreator(_collectionCommand, _CardInCollectionCommand).InsertCardInCollection(cardInCollection, IdCollection));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
