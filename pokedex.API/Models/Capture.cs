namespace Pokedex.API.Models
{
    public class Capture
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int PokemonId { get; set; }
        public DateTime CaptureDate { get; set; }
    }
}