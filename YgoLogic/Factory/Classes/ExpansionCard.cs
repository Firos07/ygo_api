
using YgoData.DataQuery.Interface;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Classes
{
    public class ExpansionCard: ICard<ExpansionDto>
    {
        private readonly IDataQuery<ExpansionDto> _ygoCardData;

        public ExpansionCard(IDataQuery<ExpansionDto> ygoCardData)
        {
            _ygoCardData = ygoCardData;
        }

        public List<ExpansionDto> DataByCodeGetList(string code)
        {
            return _ygoCardData.DataByCodeGetList(code);
        }

        public int InsertData()
        {
            throw new NotImplementedException();
        }
    }
}
