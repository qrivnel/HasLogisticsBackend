using System;
using HasLogistics.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HasLogistics.Controllers
{
    [Route("/api/[controller]")]
	public class StuffsController
	{
        

        public List<Stuff> _stuffs = new List<Stuff>();

        [HttpGet]
        public List<Stuff> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "select * from stuffs";
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Stuff stuff = new Stuff();
                        stuff.Id = reader.GetInt16(0);
                        stuff.Name = reader.GetString(1);
                        stuff.MetarialCode = reader.GetString(2);

                        _stuffs.Add(stuff);
                    }
                }
            }
            return _stuffs;
        }

        [HttpPost]
        public int GetSelectedStuff([FromBody] string name)
        {
            using(NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "select id from Stuffs where name= @name";
                using(NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = reader.GetInt16(0);
                        return id;
                    }
                    else
                        return -1;
                }
            }
        }

        [HttpPost("/api/[controller]/update")]
        public void UpdateStuff([FromBody] UpdateItem item)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "update stuffs set name=@name where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@name", item.Text);
                    command.Parameters.AddWithValue("@id", item.Id);

                    command.ExecuteReader();
                }
            }
        }

        [HttpPost("/api/[controller]/delete")]
        public void DeleteStuff([FromBody] int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "delete from stuffs where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteReader();
                }
            }
        }
    }
}

