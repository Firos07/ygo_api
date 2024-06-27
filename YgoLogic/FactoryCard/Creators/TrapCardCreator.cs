using YgoData.DataCommand.Interface;
using YgoLogic.Abstract;
using YgoLogic.Factory.Classes;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Creators
{
    public class TrapCardCreator<T> : ACardCreator<T>
    {
        private readonly IDataCommand _ygoCardData;
        private readonly CardDto _card;

        public TrapCardCreator(IDataCommand ygoCardData, CardDto card)
        {
            _ygoCardData = ygoCardData;
            _card = card;
        }

        public override ICard<T> FactoryMethod()
        {
            return new TrapCard<T>(_ygoCardData, _card);
        }
    }
}
