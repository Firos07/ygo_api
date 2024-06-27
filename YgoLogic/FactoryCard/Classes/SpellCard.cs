using YgoData.DataCommand.Interface;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Classes
{
    public class SpellCard<T> : ICard<T>
    {
        private readonly IDataCommand _ygoCardData;
        private readonly CardDto _card;

        public SpellCard(IDataCommand ygoCardData, CardDto card)
        {
            _ygoCardData = ygoCardData;
            _card = card;
        }

        public int InsertData()
        {
            return _ygoCardData.InsertCardData(_card);
        }
    }
}
