using TFTBuilder;

DataManager dataManager = DataManager.Instance;
Champion[] champions = await dataManager.GetChampionPool();

System.Console.WriteLine(string.Join(" | ", champions[0].Traits));