namespace Pokedex.API.Models
{
    public class CaptureHistory
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string MasterName { get; set; }
        public int PokemonId { get; set; }
        public DateTime CaptureDate { get; set; }
    }
}