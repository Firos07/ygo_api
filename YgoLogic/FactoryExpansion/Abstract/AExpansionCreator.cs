
using YgoLogic.FactoryExpansion.Interface;
using YgoModel;

namespace YgoLogic.FactoryExpansion.Abstract
{
    public abstract class AExpansionCreator
    {
        public abstract IExpansion FactoryMethod();        

        public List<ExpansionDto> DataByCodeCardGetList(string codeCard)
        {
            var expansion = FactoryMethod();
            var result = expansion.DataByCodeCardGetList(codeCard);

            return result;
        }
    }
}
