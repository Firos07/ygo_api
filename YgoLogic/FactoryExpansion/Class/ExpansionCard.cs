
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryExpansion.Interface;
using YgoModel;

namespace YgoLogic.FactoryExpansion.Class
{
    public class ExpansionCard : IExpansion
    {
        private readonly IExpansionQuery _ygoCardData;

        public ExpansionCard(IExpansionQuery ygoCardData)
        {
            _ygoCardData = ygoCardData;
        }

        public List<ExpansionDto> DataByCodeCardGetList(string code)
        {
            return _ygoCardData.DataByCodeGetList(code);
        }
    }
}
