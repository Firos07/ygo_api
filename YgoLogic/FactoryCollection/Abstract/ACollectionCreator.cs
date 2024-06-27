
using YgoLogic.FactoryCollection.Interface;
using YgoModel;

namespace YgoLogic.FactoryCollection.Abstract
{
    public abstract class ACollectionCreator
    {
        public abstract ICollection FactoryMethod();

        public int InsertCollection(CollectionDto collection, int IdUser)
        {
            var product = FactoryMethod();
            var result = product.InsertCollection(collection, IdUser);

            return result;
        }

        public int InsertCardInCollection(CardInCollectionDto cardInCollection, int IdCollection)
        {
            var product = FactoryMethod();
            var result = product.InsertCardInCollection(cardInCollection, IdCollection);

            return result;
        }
    }
}
