﻿
using YgoData.Interface;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.Factory
{
    public class TrapCard : ICard
    {
        private readonly IYgoDataCommand _ygoCardData;
        private readonly CardDto _card;

        public TrapCard(IYgoDataCommand ygoCardData, CardDto card)
        {
            _ygoCardData = ygoCardData;
            _card = card;
        }

        public int InsertCardLogic()
        {
            return _ygoCardData.InsertCardData(_card);
        }
    }
}
