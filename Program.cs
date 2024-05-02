using TFTBuilder;

DataManager dataManager = DataManager.Instance;
Champion[] championPool = await dataManager.GetChampionPool();
Dictionary<string, Trait> traitList = await dataManager.GetTraitList(Set.TFTSet11);


TeamBuilder teamBuilder = new(championPool, 3);
Team team = teamBuilder.GenerateBestTeam(3, traitList, 1000000);

Console.WriteLine(team);
Console.WriteLine("\n-------Traits------\n");
Console.WriteLine(team.TraitCounter);
Console.WriteLine(team.ComputeScore(traitList));

Champion[] champions = team.Champions;