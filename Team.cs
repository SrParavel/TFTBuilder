namespace TFTBuilder
{
    public class Team
    {
        public Character[] Characters { get; }
        public Dictionary<string, int> TraitCount { get; }
        public float Score { get; private set; }

        public Team(Character[] characters)
        {
            Characters = characters;
            TraitCount = [];
            Score = GetScore();
        }

        public override string ToString()
        {
            return string.Join("\n", Characters);
        }

        private float GetScore()
        {
            float result = 0f;
            //Count the acumulated traits of the team
            CountTraits();
            //Get the score of each acumulated trait
            Dictionary<string, Trait> traits = DataManager.Instance.TraitDictionary;
            foreach (KeyValuePair<string, int> kv in TraitCount)
            {
                Trait trait = traits[kv.Key];
                int count = kv.Value;
                //Add the rsult to get the final score
                result += trait.GetScore(count);
            }
            return result;
        }

        private void CountTraits()
        {
            foreach (var character in Characters)
            {
                string[] traits = character.Traits;
                foreach (var trait in traits)
                {
                    if (!TraitCount.ContainsKey(trait))
                        TraitCount[trait] = 0;
                    TraitCount[trait] += 1;
                }
            }
        }
    }
}