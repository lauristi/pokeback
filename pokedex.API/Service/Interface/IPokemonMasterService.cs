using Pokedex.API.Models.DTO;

namespace Pokedex.API.Service.Interface
{
    public interface IPokemonMasterService
    {
        Master AddMaster(MasterDTO master);
    }
}