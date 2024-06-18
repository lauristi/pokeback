using Microsoft.Data.Sqlite;
using Pokedex.API.Infrastruture.Interface;
using Pokedex.API.Models;
using Pokedex.API.Models.DTO;
using Pokedex.API.Service.Interface;

namespace Pokedex.API.Service
{
    public class CaptureService : ICaptureService
    {
        private readonly IDatabase _database;

        public CaptureService(IDatabase database)
        {
            _database = database;
        }

        public Capture CapturePokemon(CaptureDTO captureDTO)
        {
            using (var connection = new SqliteConnection(_database.Connection()))
            {
                connection.Open();

                DateTime now = DateTime.Now;
                string query = @"INSERT INTO Captures (MasterId, PokemonId, CaptureDate)
                                               VALUES (@MasterId, @PokemonId, @CaptureDate)
                                        RETURNING Id;";
                //---------------------------------------------------------------------
                var command = connection.CreateCommand();
                command.CommandText = query;

                command.Parameters.AddWithValue("@MasterId", captureDTO.MasterId);
                command.Parameters.AddWithValue("@PokemonId", captureDTO.PokemonId);
                command.Parameters.AddWithValue("@CaptureDate", now);
                //---------------------------------------------------------------------
                int newId = (int)(long)command.ExecuteScalar();

                Capture capture = new Capture();

                capture.Id = newId;
                capture.MasterId = captureDTO.MasterId;
                capture.PokemonId = captureDTO.PokemonId;
                capture.CaptureDate = now;

                return capture;
            }
        }

        public List<CaptureHistory> GetCapturedHistory()
        {
            List<CaptureHistory> captures = new List<CaptureHistory>();

            using (var connection = new SqliteConnection(_database.Connection()))
            {
                connection.Open();

                string query = @"SELECT A.Id,
                                        A.MasterId,
                                        B.Name,
                                        A.PokemonId,
                                        A.CaptureDate
                                   FROM Captures A
                                  INNER JOIN Masters B on
                                        A.MasterId = B.id;";
                //------------------------------------------
                var command = connection.CreateCommand();
                command.CommandText = query;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var captureHistory = new CaptureHistory
                        {
                            Id = reader.GetInt32(0),
                            MasterId = reader.GetInt32(1),
                            MasterName = reader.GetString(2),
                            PokemonId = reader.GetInt32(3),
                            CaptureDate = reader.GetDateTime(4)
                        };
                        captures.Add(captureHistory);
                    }
                }
            }

            return captures;
        }
    }
}