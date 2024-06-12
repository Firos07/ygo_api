
using YgoData.DataCommand;
using YgoLogic.Abstract;
using YgoLogic.Factory.Classes;
using YgoLogic.Factory.Interfaces;
using YgoModel;

namespace YgoLogic.Factory.Creators
{
    public class PendulumCardCreator<T> : ACardCreator<T>
    {
        private readonly IDataCommand _ygoCardData;
        private readonly PendulumCardDto _pendulum;

        public PendulumCardCreator(IDataCommand ygoCardData, PendulumCardDto pendulum)
        {
            _ygoCardData = ygoCardData;
            _pendulum = pendulum;
        }

        public override ICard<T> FactoryMethod()
        {
            return new PendulumCard<T>(_ygoCardData, _pendulum);
        }
    }
}
