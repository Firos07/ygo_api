
using System.Text.Json.Serialization;

namespace YgoModel
{
    public class UserDto
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? IdUser { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IdFireBase { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Email { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CollectionDto>? CollectionList { get; set; }
    }
}
