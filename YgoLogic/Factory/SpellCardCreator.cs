
using YgoData.Interface;
using YgoLogic.Abstract;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.Factory
{
    public class SpellCardCreator : ACardCreator
    {
        private readonly IYgoDataCommand _ygoCardData;
        private readonly CardDto _card;

        public SpellCardCreator(IYgoDataCommand ygoCardData, CardDto card)
        {
            _ygoCardData = ygoCardData;
            _card = card;
        }

        public override ICard FactoryMethod()
        {
            return new SpellCard(_ygoCardData, _card);
        }
    }
}
