
using YgoModel;

namespace YgoData.Interface
{
    public interface IDataCardQuery
    {
        public List<ExpansionDto> ExpansionbyCodeCardGetl(string CodeCard);
        public List<RarityDto> RaritybyCodeCardGetl(string CodeCard, int IdExtension);
    }
}
