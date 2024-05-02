using System.Text.Json;

namespace TFTBuilder
{
    class DataManager
    {
        private static DataManager? instance;
        public static DataManager Instance
        {
            get
            {
                instance ??= new DataManager();
                return instance;
            }
        }

        private HttpClient client;

        private DataManager()
        {
            client = new();

            string uri = "https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/";
            client.BaseAddress = new Uri(uri);
        }

        public async Task<Champion[]> GetChampionPool()
        {
            Stream stream = await client.GetStreamAsync("tftchampions-teamplanner.json");
            CharacterData[] characterList = await JsonSerializer.DeserializeAsync<CharacterData[]>(stream) ?? [];
            Champion[] champions = characterList.Select(character => new Champion(character)).ToArray();
            return champions;
        }

        public async Task<Trait[]> GetTraitList(Set set)
        {
            Stream stream = await client.GetStreamAsync("tfttraits.json");
            TraitData[] traitList = await JsonSerializer.DeserializeAsync<TraitData[]>(stream) ?? [];
            TraitData[] filteredData = traitList.Where(traitData => traitData.Set == set.ToString()).ToArray();
            Trait[] traits = filteredData.Select(data => new Trait(data)).ToArray();
            return traits;
        }

    }
}

enum Set
{
    TFTSet11
}