
using YgoData.Interface;
using YgoLogic.Interfaces;
using YgoModel;

namespace YgoLogic.GetData
{
    public class DataCardGetList : IDataCardGetList
    {
        private readonly IDataCardQuery _ygoCardData;

        public DataCardGetList(IDataCardQuery ygoCardData)
        {
            _ygoCardData = ygoCardData;
        }

        public List<ExpansionDto> ExpansionbyCodeCardGetl(string CodeCard)
        {
            return _ygoCardData.ExpansionbyCodeCardGetl(CodeCard);
        }

        public List<RarityDto> RaritybyCodeCardGetl(string CodeCard, int IdExtension)
        {
            return _ygoCardData.RaritybyCodeCardGetl(CodeCard, IdExtension);
        }
    }
}
