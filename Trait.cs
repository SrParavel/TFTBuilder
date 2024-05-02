namespace TFTBuilder
{
    public class Trait(TraitData traitData)
    {

        public string Name { get; } = traitData.DisplayName;
        public int[] Milestones { get; } = traitData.ConditionalTraits.Select(trait => trait.MinUnits).ToArray();
    }
}