
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryExpansion.Abstract;
using YgoLogic.FactoryExpansion.Class;
using YgoLogic.FactoryExpansion.Interface;

namespace YgoLogic.FactoryExpansion.Creator
{
    public class ExpansionCreator : AExpansionCreator
    {
        private readonly IExpansionQuery _ygoCardData;

        public ExpansionCreator(IExpansionQuery ygoCardData)
        {
            _ygoCardData = ygoCardData;
        }

        public override IExpansion FactoryMethod()
        {
            return new ExpansionCard(_ygoCardData);
        }
    }
}
