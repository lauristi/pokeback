namespace Pokedex.API.Infrastruture
{
    using global::Pokedex.API.Infrastruture.Interface;
    using Microsoft.Data.Sqlite;
    using Microsoft.Extensions.Configuration;
    using System;

    namespace Pokedex.API.Infrastruture
    {
        public class Database : IDatabase
        {
            private readonly string _conn;

            public Database(IConfiguration configuration)
            {
                _conn = configuration.GetConnectionString("DefaultConnection");
                VerifyDataBase();
            }

            public string Connection()
            {
                return _conn;
            }

            public bool VerifyDataBase()
            {
                try
                {
                    using var connection = new SqliteConnection(_conn);
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @" CREATE TABLE IF NOT EXISTS
                                         Masters (Id   INTEGER PRIMARY KEY AUTOINCREMENT,
                                                  Name TEXT NOT NULL,
                                                  Age  INTEGER NOT NULL,
                                                  CPF  TEXT NOT NULL);

                                          CREATE TABLE IF NOT EXISTS
                                          Captures (Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    MasterId    INTEGER NOT NULL,
                                                    PokemonId   INTEGER NOT NULL,
                                                    CaptureDate TEXT NOT NULL,
                                                    FOREIGN KEY(MasterId) REFERENCES Masters(Id)
                                        );";
                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw new NotImplementedException("Erro ao tentar criar o banco de dados");
                }
            }
        }
    }
}