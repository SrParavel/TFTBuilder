using System.Text.Json.Serialization;

namespace TFTBuilder
{
    public record CharacterData(string DisplayName, CharacterTrait[] Traits)
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; } = DisplayName;
        [JsonPropertyName("traits")]
        public CharacterTrait[] Traits { get; } = Traits;
    }
}