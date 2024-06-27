
using System.Text.Json.Serialization;

namespace YgoModel
{
    public class RarityDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? IdRarity { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }
    }
}
