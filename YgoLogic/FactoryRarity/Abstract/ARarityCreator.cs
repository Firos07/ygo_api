
using YgoLogic.FactoryRarity.Interface;
using YgoModel;

namespace YgoLogic.FactoryRarity.Abstract
{
    public abstract class ARarityCreator
    {
        public abstract IRarity FactoryMethod();

        public List<RarityDto> RarityByCardAndExtensionGetList(string CodeCard, int IdExtension)
        {
            var product = FactoryMethod();
            var result = product.RarityByCardAndExtensionGetList(CodeCard, IdExtension);
            return result;
        }
    }
}
