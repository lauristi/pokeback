using Pokedex.API.Models;
using Pokedex.API.Models.DTO;

namespace Pokedex.API.Service.Interface
{
    public interface ICaptureService
    {
        Capture CapturePokemon(CaptureDTO captureDTO);

        List<CaptureHistory> GetCapturedHistory();
    }
}