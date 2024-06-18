using static Pokedex.API.Models.PokemonBig;

namespace Pokedex.API.Models
{
    public class PokemonSmall
    {
        public int? id { get; set; }
        public string name { get; set; }
        public int? height { get; set; }
        public bool is_default { get; set; }
        public string location_area_encounters { get; set; }
        public int? base_experience { get; set; }
        public int? order { get; set; }

        //----------------------------------------------
        public Ability[] abilities { get; set; }

        public Cries cries { get; set; }
        public Sprites sprites { get; set; }

        #region inherited class

        public class Ability
        {
            public Ability ability { get; set; }
            public bool is_hidden { get; set; }
            public int? slot { get; set; }
        }

        public class Cries
        {
            public string latest { get; set; }
            public string legacy { get; set; }
        }

        public class Sprites
        {
            public string back_default { get; set; }
            public object back_female { get; set; }
            public string back_shiny { get; set; }
            public object back_shiny_female { get; set; }
            public string front_default { get; set; }
            public object front_female { get; set; }
            public string front_shiny { get; set; }
            public object front_shiny_female { get; set; }
            public Other other { get; set; }
            public Versions versions { get; set; }
        }

        public class Other
        {
            public Dream_World dream_world { get; set; }
            public Home home { get; set; }
            public OfficialArtwork officialartwork { get; set; }
            public Showdown showdown { get; set; }
        }

        #endregion inherited class
    }
}