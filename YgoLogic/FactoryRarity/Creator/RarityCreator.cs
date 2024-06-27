
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryRarity.Abstract;
using YgoLogic.FactoryRarity.Class;
using YgoLogic.FactoryRarity.Interface;

namespace YgoLogic.FactoryRarity.Creator
{
    public class RarityCreator : ARarityCreator
    {
        private readonly IRarityQuery _rarityQuery;

        public RarityCreator(IRarityQuery rarityQuery)
        {
            _rarityQuery = rarityQuery;
        }

        public override IRarity FactoryMethod()
        {
            return new Rarity(_rarityQuery);
        }
    }
}
