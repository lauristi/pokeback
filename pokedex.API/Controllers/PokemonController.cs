using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Models;
using Pokedex.API.Service.Interface;

namespace Pokedex.API.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public PokemonController(IMapper mapper,
                                 IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        [HttpGet("/api/pokemons/{id}")]
        public async Task<ActionResult> GetPokemonById(int id)
        {
            PokemonBig pokemon = new PokemonBig();
            try
            {
                pokemon = await _pokemonService.GetPokemonByIdAsync(id);

                if (pokemon == null)
                {
                    return NotFound("Pokémon não encontrado.");
                }
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter o pokémon: {ex.Message}");
            }
        }

        [HttpGet("/api/pokemons/random")]
        public async Task<ActionResult> GetRandomPokemonsAsync()
        {
            List<PokemonSmall> pokemons = new List<PokemonSmall>();
            try
            {
                List<PokemonBig> pokemonsBig = await _pokemonService.GetRandomPokemonsAsync();

                pokemons = _mapper.Map<List<PokemonSmall>>(pokemonsBig);

                return Ok(pokemons); // Retorna um JsonResult com a string JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter pokémons: {ex.Message}");
            }
        }
    }
}