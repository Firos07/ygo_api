
namespace YgoModel
{
    public class MonsterCardDto : CardDto
    {
        public string? MonsterAttribute { get; set; }
        public string? InnerMonsterType { get; set; }
        public short? Level_Rank_Rating { get; set; }
        public string? Atk { get; set; }
        public string? Def { get; set; }
        public bool IsEffect { get; set; }
        public bool IsTuner { get; set; }
        public bool IsGemini { get; set; }
        public bool IsUnion { get; set; }
        public bool IsToon { get; set; }
        public bool IsFlip { get; set; }
        public bool IsSpirit { get; set; }
    }
}
