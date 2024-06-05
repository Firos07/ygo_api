
using System.Text.Json.Serialization;

namespace YgoModel
{
    public class CardDto
    {
        public string? CardType { get; set; }
        public string? SubCardType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Url_Image { get; set; }
        public string? Text { get; set; }
        public List<ExpansionDto>? ExpansionList { get; set; }
    }
}
