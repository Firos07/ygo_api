
using YgoLogic.Interfaces;

namespace YgoLogic.Abstract
{
    public abstract class ACardCreator
    {
        public abstract ICard FactoryMethod();
        
        public int InsertCard()
        {
            var product = FactoryMethod();
            var result = product.InsertCardLogic();

            return result;
        }
    }
}
