
using YgoData.DataCommand;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Classes
{
    public class MonsterCard : ICard<MonsterCardDto>
    {
        private readonly IDataCommand _ygoCardData;
        private readonly MonsterCardDto _monster;

        public MonsterCard(IDataCommand ygoCardData, MonsterCardDto monster)
        {
            _ygoCardData = ygoCardData;
            _monster = monster;
        }

        public List<MonsterCardDto> DataByCodeGetList(string code)
        {
            throw new NotImplementedException();
        }

        public int InsertData()
        {
            return _ygoCardData.InsertMonsterData(_monster);
        }
    }
}
