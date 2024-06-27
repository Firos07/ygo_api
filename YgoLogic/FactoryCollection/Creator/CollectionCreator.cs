
using YgoLogic.FactoryCollection.Class;
using YgoLogic.FactoryCollection.Abstract;
using YgoLogic.FactoryCollection.Interface;
using YgoData.DataCommand.Interface;

namespace YgoLogic.FactoryCollection.Creator
{
    public class CollectionCreator : ACollectionCreator
    {
        private readonly ICollectionCommand _collectionCommand;
        private readonly ICardInCollectionCommand _CardInCollectionCommand;

        public CollectionCreator(ICollectionCommand collectionCommand, ICardInCollectionCommand cardInCollectionCommand)
        {
            _collectionCommand = collectionCommand;
            _CardInCollectionCommand = cardInCollectionCommand;
        }

        public override ICollection FactoryMethod()
        {
            return new Collection(_collectionCommand, _CardInCollectionCommand);
        }
    }
}
