using System;
using Microsoft.AspNetCore.Mvc;
using HasLogistics.Models;
using Npgsql;

namespace HasLogistics.Controllers
{
	[Route("/api/[controller]")]
	public class ClientsController
	{
		

		public List<Client> _clients = new List<Client>();

		[HttpGet]
		public List<Client> Get()
		{
			using(NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
			{
                connection.Open();
                string commandString = "select * from clients";
                using(NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
				{
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.Id = reader.GetInt16(0);
                        client.CompanyName = reader.GetString(1);
                        client.BillTitle = reader.GetString(2);
                        client.BillAddress = reader.GetString(3);
                        client.TelNo = reader.GetString(4);
                        client.Email = reader.GetString(5);

                        _clients.Add(client);
                    }
                }
                
            }
			return _clients;
		}
		
		[HttpPost]
		public int Post([FromBody] Client c)
		{
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                Client addedClient = new Client();
                string commandString = "insert into Clients (companyname, billtitle, billaddress, telno, email) values(@p1,@p2,@p3,@p4,@p5) RETURNING id";
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@p1", c.CompanyName);
                    command.Parameters.AddWithValue("@p2", c.BillTitle);
                    command.Parameters.AddWithValue("@p3", c.BillAddress);
                    command.Parameters.AddWithValue("@p4", c.TelNo);
                    command.Parameters.AddWithValue("@p5", c.Email);
                    int insertedId = (int)command.ExecuteScalar();
                    return insertedId;
                }
            }
		}

        [HttpPost("/api/[controller]/update")]
        public void UpdateClients([FromBody] UpdateItem item)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "update clients set companyname=@name where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@name", item.Text);
                    command.Parameters.AddWithValue("@id", item.Id);

                    command.ExecuteReader();
                }
            }
        }

        [HttpPost("/api/[controller]/delete")]
        public void DeleteClient([FromBody] int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "delete from clients where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteReader();
                }
            }
        }
    }
}

