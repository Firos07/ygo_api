
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryCard.Interfaces;
using YgoModel;

namespace YgoLogic.FactoryCard.Classes
{
    public class Card : ICardGet
    {
        private readonly ICardQuery _cardQuery;

        public Card(ICardQuery cardQuery)
        {
            _cardQuery = cardQuery;
        }

        public List<CardDto> AllCardGetList() 
        {
            return _cardQuery.AllCardGetList();
        }
    }
}
