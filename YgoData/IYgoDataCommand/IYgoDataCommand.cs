
using YgoModel;

namespace YgoData.Interface
{
    public interface IYgoDataCommand
    {
        public int InsertCardData(CardDto card);
        public int InsertMonsterData(MonsterCardDto monster);
        public int InsertPendulumData(PendulumCardDto pendulum);
    }
}
