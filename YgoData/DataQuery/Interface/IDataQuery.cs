
namespace YgoData.DataQuery.Interface
{
    public interface IDataQuery<T>
    {
        public List<T> DataByCodeGetList(string Code);
        public List<T> DataByCodeGetList(string Code, int Id);
    }
}
