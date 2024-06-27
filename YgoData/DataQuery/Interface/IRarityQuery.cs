
using YgoModel;

namespace YgoData.DataQuery.Interface
{
    public interface IRarityQuery
    {
        public List<RarityDto> RarityByCardAndExtensionGetList(string CodeCard, int IdExtension);
    }
}
