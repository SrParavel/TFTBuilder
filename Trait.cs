
namespace TFTBuilder
{
    public class Trait
    {
        public string Name { get; }
        public int[] Milestones { get; }
        public float[] Scores { get; }

        public Trait(TraitData traitData)
        {
            Name = traitData.DisplayName;
            Milestones = traitData.ConditionalTraits.Select(trait => trait.MinUnits).ToArray();
            Scores = new float[Milestones.Length];
            for (int i = 0; i < Milestones.Length; i++)
            {
                int milestone = i + 1;
                Scores[i] = milestone * (milestone + 1f) / (2f * Milestones.Length);
            }
        }

        public int GetCurrentMilestone(int amount)
        {
            return Milestones.Count(milestone => amount >= milestone) - 1;
        }

        public override string ToString()
        {
            return $"{Name} > [ {string.Join(", ", Milestones)} ]";
        }
    }
}