namespace TFTBuilder
{
    public class Champion(CharacterData data)
    {
        public string Name { get; } = data.DisplayName;
        public int Tier { get; } = data.Tier;
        public string[] Traits { get; } = data.Traits.Select(trait => trait.Name).ToArray();

        public override string ToString()
        {
            return $"{Name} ({Tier}) > [ {string.Join(" | ", Traits)} ]";
        }
    }
}