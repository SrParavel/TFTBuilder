using System.Text.Json.Serialization;

namespace TFTBuilder
{
    public record ConditionalTrait(int MinUnits)
    {
        [JsonPropertyName("min_units")]
        public int MinUnits { get; } = MinUnits;

        public override string ToString()
        {
            return MinUnits.ToString();
        }
    }
}