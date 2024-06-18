using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Models.DTO;
using Pokedex.API.Service.Interface;

namespace Pokedex.API.Controllers
{
    public class CaptureController : Controller
    {
        private readonly ICaptureService _captureService;

        public CaptureController(ICaptureService captureService)
        {
            _captureService = captureService;
        }

        [HttpPost("/api/captures")]
        public IActionResult CapturePokemon([FromBody] CaptureDTO captureDTO)
        {
            try
            {
                var capture = _captureService.CapturePokemon(captureDTO);

                return Created($"/api/captures/{capture.Id}", capture);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao registrar o pokémon: {ex.Message}");
            }
        }

        [HttpGet("/api/captures")]
        public IActionResult GetCapturedPokemons()
        {
            try
            {
                var captures = _captureService.GetCapturedHistory();
                return Ok(captures);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter os pokémons: {ex.Message}");
            }
        }
    }
}