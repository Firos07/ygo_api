
using YgoModel;

namespace YgoData.DataQuery.Interface
{
    public interface IExpansionQuery
    {
        public List<ExpansionDto> DataByCodeGetList(string Code);        
    }
}
