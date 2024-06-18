using Newtonsoft.Json;
using Pokedex.API.Infrastruture.Interface;
using Pokedex.API.Models;
using Pokedex.API.Service.Interface;

namespace Pokedex.API.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly IDatabase _database;
        private readonly IHttpClientService _httpClientService;

        public PokemonService(IDatabase database, IHttpClientService httpClientService)
        {
            _database = database;
            _httpClientService = httpClientService;
        }

        public async Task<PokemonBig> GetPokemonByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClientService.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}/");

            PokemonBig pokemon = new PokemonBig();

            if (response.IsSuccessStatusCode)
            {
                string largeJson = await response.Content.ReadAsStringAsync();
                pokemon = JsonConvert.DeserializeObject<PokemonBig>(largeJson);

                return pokemon;
            }
            else
            {
                Console.WriteLine($"Erro ao obter dados de pokeapi");
                return null;
            }
        }

        public async Task<List<PokemonBig>> GetRandomPokemonsAsync()
        {
            
            
            
            // 1 RECUPERO O TOTAL DE POKEMONS
            HttpResponseMessage responseRoot = await _httpClientService.GetAsync("https://pokeapi.co/api/v2/pokemon");

            if (responseRoot.IsSuccessStatusCode)
            {
                string jsonRoot = await responseRoot.Content.ReadAsStringAsync();
                PokemonRoot pokemonRoot = JsonConvert.DeserializeObject<PokemonRoot>(jsonRoot);

                List<PokemonBig> pokemons = new List<PokemonBig>();

                Random rnd = new Random(pokemonRoot.count);

                // APARENTEMENTE A LISYA POKEMON NÃO E SEQUENCIAL E FALTAM NUNEROS NELA
                int c = 0;
                while (c < 10)
                {
                    // 2 RECUPERO DADO COMPLETO DO POKEMON
                    int pokemonID = rnd.Next(pokemonRoot.count);
                    HttpResponseMessage response = await _httpClientService.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonID}/");

                    if (response.IsSuccessStatusCode)
                    {
                        string largeJson = await response.Content.ReadAsStringAsync();
                        PokemonBig pokemon = JsonConvert.DeserializeObject<PokemonBig>(largeJson);
                        //----------------------------------------------------------------
                        pokemons.Add(pokemon);
                        c++;
                    }
                }

                return pokemons;
            }
            else
            {
                Console.WriteLine($"Erro ao obter dados de pokeapi");
                return null;
            }
        }
    }
}