namespace TFTBuilder
{
    public class TeamBuilder
    {
        readonly Random random;
        readonly Character[] characters;

        public TeamBuilder(Character[] championPool, int maxTier)
        {
            random = new Random();
            characters = championPool.Where(champion => champion.Tier <= maxTier).ToArray();
        }

        public Team GenerateRandom(Character[] baseCharacters, int mutations, int size, int iterations)
        {
            Team bestTeam = GenerateRandom(baseCharacters, mutations, size);
            float bestScore = bestTeam.Score;

            for (int i = 0; i < iterations; i++)
            {
                double completed = (double)i / iterations * 100;
                if (completed % 1 == 0)
                {
                    string message = $"Calculated: {completed}%";
                    Console.Write($"\r{message}");
                }

                Team currentTeam = GenerateRandom(baseCharacters, mutations, size);
                float currentScore = currentTeam.Score;

                if (currentScore > bestScore)
                {
                    bestScore = currentScore;
                    bestTeam = currentTeam;
                }
            }

            Console.Write("\r");

            return bestTeam;
        }

        public Team GenerateRandom(int size)
        {
            return GenerateRandom([], 0, size);
        }

        public Team GenerateRandom(Character[] baseCharacters, int mutations, int size)
        {
            List<Character> result = new(baseCharacters);

            for (int i = 0; i < mutations; i++)
            {
                int index = random.Next(result.Count);
                result.RemoveAt(index);
            }

            while (result.Count < size)
            {
                int i = random.Next(0, characters.Length);
                Character randomCharacter = characters[i];
                if (!result.Contains(randomCharacter))
                    result.Add(randomCharacter);
            }

            return new Team([.. result]);
        }

    }
}