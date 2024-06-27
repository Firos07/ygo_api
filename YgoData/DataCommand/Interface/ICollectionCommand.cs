
using YgoModel;

namespace YgoData.DataCommand.Interface
{
    public interface ICollectionCommand
    {
        public int InsertCollection(CollectionDto collection, int IdUser);
    }
}
