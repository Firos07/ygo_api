
using YgoData.Interface;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.Factory
{
    public class PendulumCard : ICard
    {
        private readonly IYgoDataCommand _ygoCardData;
        private readonly PendulumCardDto _pendulum;

        public PendulumCard(IYgoDataCommand ygoCardData, PendulumCardDto pendulum)
        {
            _ygoCardData = ygoCardData;
            _pendulum = pendulum;
        }

        public int InsertCardLogic()
        {
            return _ygoCardData.InsertPendulumData(_pendulum);
        }
    }
}
