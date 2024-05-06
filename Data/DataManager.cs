using System.Text.Json;

namespace TFTBuilder
{
    class DataManager
    {
        private static DataManager? instance;
        public static DataManager Instance { get { return instance ??= new DataManager(); } }

        public Dictionary<string, Trait> TraitDictionary { get; private set; } = [];
        public Dictionary<string, Character> CharacterDictionary { get; private set; } = [];

        private readonly HttpClient client;
        private readonly string uri;

        public DataManager()
        {
            client = new();
            uri = "https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/";
            client.BaseAddress = new(uri);
        }

        public async Task LoadData(Set set)
        {
            TraitDictionary = await LoadTraits(set);
            CharacterDictionary = await LoadCharacters(set);
        }

        private async Task<Dictionary<string, Trait>> LoadTraits(Set set)
        {
            Stream stream = await client.GetStreamAsync("tfttraits.json");
            TraitModel[] model = await JsonSerializer.DeserializeAsync<TraitModel[]>(stream) ?? [];
            TraitModel[] filteredModels = model.Where(m => m.Set == set.ToString()).ToArray();
            Trait[] traits = filteredModels.Select(fm => new Trait(fm)).ToArray();
            return traits.ToDictionary(t => t.Name);
        }

        private async Task<Dictionary<string, Character>> LoadCharacters(Set set)
        {
            Stream stream = await client.GetStreamAsync("tftchampions-teamplanner.json");
            CharacterModel[] models = await JsonSerializer.DeserializeAsync<CharacterModel[]>(stream) ?? [];
            Character[] characters = models.Select(m => new Character(m)).ToArray();
            return characters.ToDictionary(c => c.Name);
        }

    }
}

enum Set
{
    TFTSet11
}