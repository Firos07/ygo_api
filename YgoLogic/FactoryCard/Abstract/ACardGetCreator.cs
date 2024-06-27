
using YgoLogic.FactoryCard.Interfaces;
using YgoModel;

namespace YgoLogic.FactoryCard.Abstract
{
    public abstract class ACardGetCreator
    {
        public abstract ICardGet FactoryMethod();

        public List<CardDto> AllCardGetList()
        {
            var factory = FactoryMethod();
            var result = factory.AllCardGetList();

            return result;
        }
    }
}
