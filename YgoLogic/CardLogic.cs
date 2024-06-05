
using YgoLogic.Abstract;

namespace YgoLogic
{
    public class CardLogic : ICardLogic
    {        
        public int Insert(ACardCreator aCardCreator) {
            return aCardCreator.InsertCard();
        }
    }
}
