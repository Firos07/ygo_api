
using YgoLogic.Factory.Interfaces;

namespace YgoLogic.Abstract
{
    public abstract class ACardCreator<T>
    {
        public abstract ICard<T> FactoryMethod();
        
        public int InsertData()
        {
            var product = FactoryMethod();
            var result = product.InsertData();

            return result;
        }       

    }
}
