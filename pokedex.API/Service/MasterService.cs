namespace Pokedex.API.Service
{
    using global::Pokedex.API.Infrastruture.Interface;
    using global::Pokedex.API.Models.DTO;
    using global::Pokedex.API.Service.Interface;
    using Microsoft.Data.Sqlite;

    namespace Pokedex.API.Service
    {
        public class PokemonMasterService : IPokemonMasterService
        {
            private readonly IDatabase _database;

            public PokemonMasterService(IDatabase database)
            {
                _database = database;
            }

            public Master AddMaster(MasterDTO masterDTO)
            {
                using (var connection = new SqliteConnection(_database.Connection()))
                {
                    connection.Open();

                    string query = @"INSERT INTO Masters (Name, Age, CPF)
                                                  VALUES (@Name, @Age, @CPF)
                                       RETURNING Id;";
                    //---------------------------------------------------------------------
                    var command = connection.CreateCommand();
                    command.CommandText = query;

                    command.Parameters.AddWithValue("@Name", masterDTO.Name);
                    command.Parameters.AddWithValue("@Age", masterDTO.Age);
                    command.Parameters.AddWithValue("@CPF", masterDTO.CPF);
                    //---------------------------------------------------------------------
                    int newId = (int)(long)command.ExecuteScalar();

                    Master master = new Master();

                    master.Id = newId;
                    master.Name = masterDTO.Name;
                    master.Age = masterDTO.Age;
                    master.CPF = masterDTO.CPF;

                    return master;
                }
            }
        }
    }
}