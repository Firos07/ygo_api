using YgoData.DataCommand.Interface;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Classes
{
    public class PendulumCard<T> : ICard<T>
    {
        private readonly IDataCommand _ygoCardData;
        private readonly PendulumCardDto _pendulum;

        public PendulumCard(IDataCommand ygoCardData, PendulumCardDto pendulum)
        {
            _ygoCardData = ygoCardData;
            _pendulum = pendulum;
        }

        public int InsertData()
        {
            return _ygoCardData.InsertPendulumData(_pendulum);
        }
    }
}
