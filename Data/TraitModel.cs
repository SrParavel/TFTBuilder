using System.Text.Json.Serialization;

namespace TFTBuilder
{
    public readonly record struct TraitModel(
        [property: JsonPropertyName("display_name")] string Name,
        [property: JsonPropertyName("set")] string Set,
        [property: JsonPropertyName("conditional_trait_sets")] ConditionalTrait[] ConditionalTraits
    );

    public readonly record struct ConditionalTrait(
        [property: JsonPropertyName("min_units")] int MinUnits);

}