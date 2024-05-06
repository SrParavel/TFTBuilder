
namespace TFTBuilder
{
    public readonly struct Trait
    {
        public string Name { get; }
        public int[] Milestones { get; }
        public float[] Scores { get; }

        public Trait(TraitModel traitModel)
        {
            Name = traitModel.Name;
            Milestones = traitModel.ConditionalTraits.Select(ct => ct.MinUnits).ToArray();
            float count = 2f * Milestones.Length;
            Scores = Milestones.Select((m, index) => (index + 1f) * (index + 2f) / count).ToArray();
        }

        internal float GetScore(int count)
        {
            //Get the current milestone
            int currentMilestone = GetMilestone(count);
            return currentMilestone >= 0 ? Scores[currentMilestone] : 0;
        }

        private int GetMilestone(int count)
        {
            int currentMilestone = -1;
            for (int i = 0; i < Milestones.Length; i++)
            {
                if (count < Milestones[i]) break;
                currentMilestone = i;
            }

            return currentMilestone;
        }

        public override string ToString()
        {
            return $"{Name}> [{string.Join(", ", Milestones)}][{string.Join(", ", Scores)}]";
        }
    }
}