using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YgoData.Interface;
using YgoLogic.Abstract;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.Factory
{
    public class PendulumCardCreator : ACardCreator
    {
        private readonly IYgoDataCommand _ygoCardData;
        private readonly PendulumCardDto _pendulum;

        public PendulumCardCreator(IYgoDataCommand ygoCardData, PendulumCardDto pendulum)
        {
            _ygoCardData = ygoCardData;
            _pendulum = pendulum;
        }

        public override ICard FactoryMethod()
        {
            return new PendulumCard(_ygoCardData, _pendulum);
        }
    }
}
