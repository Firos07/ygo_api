
namespace YgoLogic.Factory.Interfaces
{
    public interface ICard<T>
    {
        public int InsertData();
        public List<T> DataByCodeGetList(string code);
    }
}
