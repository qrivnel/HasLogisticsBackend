using System;
using HasLogistics.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HasLogistics.Controllers
{
    [Route("/api/[controller]")]
    public class TrailersController
    {
        NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString);

        public List<Trailer> _trailers = new List<Trailer>();

        [HttpGet]
        public List<Trailer> Get()
        {
            connection.Open();
            string commandString = "select * from trailers";
            NpgsqlCommand command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Trailer trailer = new Trailer();
                trailer.Id = reader.GetInt16(0);
                trailer.LastStuffKind = reader.GetString(1);
                trailer.Plate = reader.GetString(2);
                trailer.IsClean = reader.GetBoolean(3);
                trailer.Type = reader.GetString(4);
                trailer.LastInspectionDate = reader.GetDateTime(5);
                trailer.Suitability = reader.GetBoolean(6);

                _trailers.Add(trailer);
            }
            connection.Close();
            return _trailers;
        }

        [HttpGet("/api/[controller]/suitabletrailers")]
        public List<Trailer> GetSuitableTrucks()
        {
            connection.Open();
            string commandString = "select * from trailers where suitability='true'";
            NpgsqlCommand command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Trailer trailer = new Trailer();
                trailer.Id = reader.GetInt16(0);
                trailer.LastStuffKind = reader.GetString(1);
                trailer.Plate = reader.GetString(2);
                trailer.IsClean = reader.GetBoolean(3);
                trailer.Type = reader.GetString(4);
                trailer.LastInspectionDate = reader.GetDateTime(5);
                trailer.Suitability = reader.GetBoolean(6);

                _trailers.Add(trailer);
            }
            return _trailers;
        }

        [HttpPost("/api/[controller]/update")]
        public void UpdateTrailer([FromBody] UpdateItem item)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "update trailers set plate=@name where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@name", item.Text);
                    command.Parameters.AddWithValue("@id", item.Id);

                    command.ExecuteReader();
                }
            }
        }

        [HttpPost("/api/[controller]/delete")]
        public void DeleteTrailer([FromBody] int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "delete from trailers where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteReader();
                }
            }
        }
    }
}

