
using YgoData.DataCommand.Interface;
using YgoLogic.FactoryCollection.Interface;
using YgoModel;

namespace YgoLogic.FactoryCollection.Class
{
    public class Collection : ICollection
    {
        private readonly ICollectionCommand _collectionCommand;
        private readonly ICardInCollectionCommand _CardInCollectionCommand;

        public Collection(ICollectionCommand collectionCommand, ICardInCollectionCommand cardInCollectionCommand)
        {
            _collectionCommand = collectionCommand;
            _CardInCollectionCommand = cardInCollectionCommand;
        }

        public int InsertCollection(CollectionDto collection, int IdUser)
        {
            return _collectionCommand.InsertCollection(collection, IdUser);
        }

        public int InsertCardInCollection(CardInCollectionDto cardInCollection, int IdCollection)
        {
            return _CardInCollectionCommand.InsertCardInCollection(cardInCollection, IdCollection);
        }
    }
}
