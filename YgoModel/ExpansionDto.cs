
namespace YgoModel
{
    public class ExpansionDto
    {
        public int? IdExpansion { get; set; } 
        public string? Code { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<RarityDto>? RarityList { get; set; }
    }
}
