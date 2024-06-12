
using YgoData.DataCommand;
using YgoLogic.Abstract;
using YgoLogic.Factory.Interfaces;
using YgoLogic.Factory.Classes;
using YgoModel;

namespace YgoLogic.Factory.Creators
{
    public class MonsterCardCreator : ACardCreator<MonsterCardDto>
    {
        private readonly IDataCommand _ygoCardData;
        private readonly MonsterCardDto _monster;

        public MonsterCardCreator(IDataCommand ygoCardData, MonsterCardDto monster)
        {
            _ygoCardData = ygoCardData;
            _monster = monster;
        }

        public override ICard<MonsterCardDto> FactoryMethod()
        {
            return new MonsterCard(_ygoCardData, _monster);
        }
    }
}
