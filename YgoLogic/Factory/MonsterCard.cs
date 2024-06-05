
using YgoData.Interface;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.Factory
{
    public class MonsterCard : ICard
    {
        private readonly IYgoDataCommand _ygoCardData;
        private readonly MonsterCardDto _monster;

        public MonsterCard(IYgoDataCommand ygoCardData, MonsterCardDto monster)
        {
            _ygoCardData = ygoCardData;
            _monster = monster;
        }

        public int InsertCardLogic()
        {
            return _ygoCardData.InsertMonsterData(_monster);
        }
    }
}
