using System;
using HasLogistics.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HasLogistics.Controllers
{
    [Route("/api/[controller]")]
    public class TrucksController
    {
        NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString);

        public List<Truck> _trucks = new List<Truck>();

        [HttpGet]
        public List<Truck> Get()
        {
            connection.Open();
            string commandString = "select * from trucks";
            NpgsqlCommand command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Truck truck = new Truck();
                truck.Id = reader.GetInt16(0);
                truck.StaffId = reader.GetInt16(1);
                truck.Plate = reader.GetString(2);
                truck.LastInspectionDate = reader.GetDateTime(3);
                truck.Suitability = reader.GetBoolean(4);

                _trucks.Add(truck);
            }
            connection.Close();
            return _trucks;
        }

        [HttpGet("/api/[controller]/suitabletrucks")]
        public List<Truck> GetSuitableTrucks()
        {
            connection.Open();
            string commandString = "select * from trucks where suitability='true'";
            NpgsqlCommand command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Truck truck = new Truck();
                truck.Id = reader.GetInt16(0);
                truck.StaffId = reader.GetInt16(1);
                truck.Plate = reader.GetString(2);
                truck.LastInspectionDate = reader.GetDateTime(3);
                truck.Suitability = reader.GetBoolean(4);

                _trucks.Add(truck);
            }
            return _trucks;
        }

        [HttpPost("/api/[controller]/update")]
        public void UpdateTruck([FromBody] UpdateItem item)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "update trucks set plate=@name where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@name", item.Text);
                    command.Parameters.AddWithValue("@id", item.Id);

                    command.ExecuteReader();
                }
            }
        }

        [HttpPost("/api/[controller]/delete")]
        public void DeleteTruck([FromBody] int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "delete from trucks where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteReader();
                }
            }
        }
    }
}
