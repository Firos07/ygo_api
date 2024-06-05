
using YgoData.Interface;
using YgoLogic.Abstract;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.Factory
{
    public class MonsterCardCreator : ACardCreator
    {
        private readonly IYgoDataCommand _ygoCardData;
        private readonly MonsterCardDto _monster;

        public MonsterCardCreator(IYgoDataCommand ygoCardData, MonsterCardDto monster)
        {
            _ygoCardData = ygoCardData;
            _monster = monster;
        }

        public override ICard FactoryMethod()
        {
            return new MonsterCard(_ygoCardData, _monster);
        }
    }
}
