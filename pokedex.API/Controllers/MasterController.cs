using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Models.DTO;
using Pokedex.API.Service.Interface;

namespace Pokedex.API.Controllers
{
    public class MasterController : Controller
    {
        private readonly IPokemonMasterService _PokemonMasterService;

        public MasterController(IPokemonMasterService PokemonMasterService)
        {
            _PokemonMasterService = PokemonMasterService;
        }

        [HttpPost("/api/masters")]
        public IActionResult AddMaster([FromBody] MasterDTO masterDTO)
        {
            try
            {
                var master = _PokemonMasterService.AddMaster(masterDTO);
                return Created($"/api/masters/{master.Id}", master);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar o mestre pokémon: {ex.Message}");
            }
        }
    }
}