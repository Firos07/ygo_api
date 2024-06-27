
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryRarity.Interface;
using YgoModel;

namespace YgoLogic.FactoryRarity.Class
{
    public class Rarity : IRarity
    {
        private readonly IRarityQuery _rarityQuery;

        public Rarity(IRarityQuery rarityQuery)
        {
            _rarityQuery = rarityQuery;
        }

        public List<RarityDto> RarityByCardAndExtensionGetList(string CodeCard, int IdExtension)
        {
            return _rarityQuery.RarityByCardAndExtensionGetList(CodeCard, IdExtension);
        }
    }
}
