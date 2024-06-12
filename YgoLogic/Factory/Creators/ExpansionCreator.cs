
using YgoData.DataQuery.Interface;
using YgoLogic.Abstract;
using YgoLogic.Factory.Classes;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Creators
{
    public class ExpansionCreator : ACardCreator<ExpansionDto>
    {
        private readonly IDataQuery<ExpansionDto> _ygoCardData;

        public ExpansionCreator(IDataQuery<ExpansionDto> ygoCardData)
        {
            _ygoCardData = ygoCardData;
        }

        public override ICard<ExpansionDto> FactoryMethod()
        {
            return new ExpansionCard(_ygoCardData);
        }
    }
}
