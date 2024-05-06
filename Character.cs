namespace TFTBuilder
{
    public readonly struct Character(CharacterModel characterModel)
    {
        public string Name { get; } = characterModel.Name;
        public int Tier { get; } = characterModel.Tier;
        public string[] Traits { get; } = characterModel.CharacterTraits.Select(ct => ct.Name).ToArray();

        public override string ToString()
        {
            return $"{Name}({Tier})> {string.Join(", ", Traits)}";
        }
    }
}