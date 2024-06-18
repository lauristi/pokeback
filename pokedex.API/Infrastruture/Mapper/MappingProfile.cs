using AutoMapper;
using Pokedex.API.Models;

namespace Pokedex.API.Infrastruture.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokemonBig, PokemonSmall>();

            //Classes aninhadas tb precisam ser mapeadas
            CreateMap<PokemonBig.Ability, PokemonSmall.Ability>();
            CreateMap<PokemonBig.Ability1, PokemonSmall.Ability>();
            CreateMap<PokemonBig.Cries, PokemonSmall.Cries>();
            CreateMap<PokemonBig.Sprites, PokemonSmall.Sprites>();
            CreateMap<PokemonBig.Other, PokemonSmall.Other>();
        }
    }
}