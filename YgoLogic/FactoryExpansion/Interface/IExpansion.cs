
using YgoModel;

namespace YgoLogic.FactoryExpansion.Interface
{
    public interface IExpansion
    {
        public List<ExpansionDto> DataByCodeCardGetList(string code);
    }
}
