
using System.Text.Json.Serialization;

namespace YgoModel
{
    public class PendulumCardDto : MonsterCardDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PendulumScale { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PendulumText { get; set; }
    }
}
