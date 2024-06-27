using YgoModel;

namespace YgoData.DataCommand.Interface
{
    public interface IDataCommand
    {
        public int InsertCardData(CardDto card);
        public int InsertMonsterData(MonsterCardDto monster);
        public int InsertPendulumData(PendulumCardDto pendulum);
    }
}
