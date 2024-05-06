using System.Text.Json.Serialization;

namespace TFTBuilder
{

    public readonly record struct CharacterModel(
        [property: JsonPropertyName("display_name")] string Name,
        [property: JsonPropertyName("tier")] int Tier,
        [property: JsonPropertyName("traits")] CharacterTrait[] CharacterTraits);

    public record CharacterTrait(
        [property: JsonPropertyName("name")] string Name);
}