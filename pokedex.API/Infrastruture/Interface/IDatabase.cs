namespace Pokedex.API.Infrastruture.Interface
{
    public interface IDatabase
    {
        bool VerifyDataBase();

        string Connection();
    }
}