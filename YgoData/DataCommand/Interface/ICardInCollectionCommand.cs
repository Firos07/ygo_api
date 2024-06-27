
using YgoModel;

namespace YgoData.DataCommand.Interface
{
    public interface ICardInCollectionCommand
    {
        public int InsertCardInCollection(CardInCollectionDto cardInCollection, int IdCollection);
    }
}
