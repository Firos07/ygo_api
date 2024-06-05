
using YgoModel;

namespace YgoLogic.Interfaces
{
    public interface IDataCardGetList
    {
        public List<ExpansionDto> ExpansionbyCodeCardGetl(string CodeCard);

        public List<RarityDto> RaritybyCodeCardGetl(string CodeCard, int IdExtension);
    }
}
