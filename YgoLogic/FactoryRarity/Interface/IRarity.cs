
using YgoModel;

namespace YgoLogic.FactoryRarity.Interface
{
    public interface IRarity
    {
        public List<RarityDto> RarityByCardAndExtensionGetList(string CodeCard, int IdExtension);
    }
}
