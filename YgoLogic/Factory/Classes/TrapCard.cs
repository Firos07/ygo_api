
using YgoData.DataCommand;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Classes
{
    public class TrapCard<T> : ICard<T>
    {
        private readonly IDataCommand _ygoCardData;
        private readonly CardDto _card;

        public TrapCard(IDataCommand ygoCardData, CardDto card)
        {
            _ygoCardData = ygoCardData;
            _card = card;
        }

        public List<T> DataByCodeGetList(string code)
        {
            throw new NotImplementedException();
        }

        public int InsertData()
        {
            return _ygoCardData.InsertCardData(_card);
        }
    }
}
