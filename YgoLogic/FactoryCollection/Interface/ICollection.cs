
using YgoModel;

namespace YgoLogic.FactoryCollection.Interface
{
    public  interface ICollection
    {
        public int InsertCollection(CollectionDto collection, int IdUser);
        public int InsertCardInCollection(CardInCollectionDto cardInCollection, int IdCollection);
    }
}
