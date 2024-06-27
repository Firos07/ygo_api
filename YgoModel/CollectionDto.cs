
using System.Text.Json.Serialization;
using YgoModel.Enum;

namespace YgoModel
{
    public class CollectionDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? IdCollection { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CollectionType CollectionType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CardInCollectionDto>? CardInCollectionList { get; set; }
    }
}
