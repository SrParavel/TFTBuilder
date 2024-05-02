using System.Text.Json.Serialization;

namespace TFTBuilder
{
    public record CharacterData(string DisplayName, int Tier, CharacterTrait[] Traits)
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; } = DisplayName;
        [JsonPropertyName("tier")]
        public int Tier { get; } = Tier;
        [JsonPropertyName("traits")]
        public CharacterTrait[] Traits { get; } = Traits;
    }
}