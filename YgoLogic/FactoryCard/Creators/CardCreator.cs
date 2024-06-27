
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryCard.Abstract;
using YgoLogic.FactoryCard.Classes;
using YgoLogic.FactoryCard.Interfaces;

namespace YgoLogic.FactoryCard.Creators
{
    public class CardCreator : ACardGetCreator
    {
        private readonly ICardQuery _cardQuery;

        public CardCreator(ICardQuery cardQuery)
        {
            _cardQuery = cardQuery;
        }

        public override ICardGet FactoryMethod()
        {
            return new Card(_cardQuery);
        }
    }
}
