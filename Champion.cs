namespace TFTBuilder
{
    public class Champion(CharacterData data)
    {
        public string Name { get; } = data.DisplayName;
        public string[] Traits { get; } = data.Traits.Select(trait => trait.Name).ToArray();
    }
}