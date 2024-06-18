namespace Pokedex.API.Infrastruture.Interface
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}