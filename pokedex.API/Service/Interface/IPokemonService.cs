using Pokedex.API.Models;

namespace Pokedex.API.Service.Interface
{
    public interface IPokemonService
    {
        Task<List<PokemonBig>> GetRandomPokemonsAsync();

        Task<PokemonBig> GetPokemonByIdAsync(int id);
    }
}