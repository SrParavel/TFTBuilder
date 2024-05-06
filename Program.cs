using TFTBuilder;

DataManager dataManager = DataManager.Instance;
await dataManager.LoadData(Set.TFTSet11);
Dictionary<string, Character> characterDictionary = dataManager.CharacterDictionary;
Character[] characters = [.. characterDictionary.Values];
Character[] baseTeam = {
    characterDictionary["Malphite"],
    characterDictionary["Rek'Sai"],
    characterDictionary["Aphelios"],
    characterDictionary["Lissandra"],
    characterDictionary["Nautilus"]
    };

TeamBuilder teamBuilder = new(characters, 3);
Team team = teamBuilder.GenerateRandom(baseTeam, 3, 6, 1000000);

Console.WriteLine(team);
Console.WriteLine(team.Score);


