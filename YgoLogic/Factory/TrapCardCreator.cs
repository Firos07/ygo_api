
using YgoData.Interface;
using YgoLogic.Abstract;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.Factory
{
    public class TrapCardCreator : ACardCreator
    {
        private readonly IYgoDataCommand _ygoCardData;
        private readonly CardDto _card;

        public TrapCardCreator(IYgoDataCommand ygoCardData, CardDto card)
        {
            _ygoCardData = ygoCardData;
            _card = card;
        }

        public override ICard FactoryMethod()
        {
            return new TrapCard(_ygoCardData, _card);
        }
    }
}
