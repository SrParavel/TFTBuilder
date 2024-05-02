using System.Text.Json.Serialization;

namespace TFTBuilder
{
    public record CharacterTrait(string Name)
    {
        [JsonPropertyName("name")]
        public string Name { get; } = Name;
    }
}