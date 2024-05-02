using System.Text.Json.Serialization;

namespace TFTBuilder
{
    public record TraitData(string DisplayName, string Set, ConditionalTrait[] ConditionalTraits)
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = DisplayName;
        [JsonPropertyName("set")]
        public string Set { get; set; } = Set;
        [JsonPropertyName("conditional_trait_sets")]
        public ConditionalTrait[] ConditionalTraits { get; } = ConditionalTraits;

    }
}