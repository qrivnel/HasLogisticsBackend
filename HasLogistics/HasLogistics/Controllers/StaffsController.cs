using System;
using Microsoft.AspNetCore.Mvc;
using HasLogistics.Models;
using Npgsql;

namespace HasLogistics.Controllers
{
	[Route("/api/[controller]")]
	public class StaffsController
	{
		public List<Staff> _staffs = new List<Staff>();

        [HttpGet]
        public List<Staff> Get()
		{
            using(NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "select * from staffs";
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Staff staff = new Staff();

                        staff.Id = reader.GetInt16(0);
                        staff.Name = reader.GetString(1);
                        staff.Surname = reader.GetString(2);
                        staff.Sex = reader.GetString(3);
                        staff.Age = reader.GetInt16(4);
                        staff.Salary = reader.GetDecimal(5);

                        staff.EnterDate = reader.GetDateTime(6);
                        staff.ExitDate = reader.IsDBNull(7) ? null : reader.GetDateTime(7);

                        staff.Department = reader.GetString(8);
                        staff.Suitability = reader.GetBoolean(9);

                        _staffs.Add(staff);
                    }
                }
            }
			return _staffs;
		}

        [HttpGet("/api/[controller]/{id}")]
        public List<Staff> Get(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "select * from staffs where id=@id";
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Staff staff = new Staff();

                        staff.Id = reader.GetInt16(0);
                        staff.Name = reader.GetString(1);
                        staff.Surname = reader.GetString(2);
                        staff.Sex = reader.GetString(3);
                        staff.Age = reader.GetInt16(4);
                        staff.Salary = reader.GetDecimal(5);

                        staff.EnterDate = reader.GetDateTime(6);
                        staff.ExitDate = reader.IsDBNull(7) ? null : reader.GetDateTime(7);

                        staff.Department = reader.GetString(8);
                        staff.Suitability = reader.GetBoolean(9);

                        _staffs.Add(staff);
                    }
                }
            }
            return _staffs;
        }

		[HttpGet("/api/[controller]/suitablestaffs")]
		public List<Staff> GetSuitableDriver()
		{
            using(NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "select * from staffs where department='Şoför' and suitability='true'";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Staff staff = new Staff();

                        staff.Id = reader.GetInt16(0);

                        staff.Name = reader.GetString(1);
                        staff.Surname = reader.GetString(2);
                        staff.Sex = reader.GetString(3);
                        staff.Age = reader.GetInt16(4);
                        staff.Salary = reader.GetDecimal(5);

                        staff.EnterDate = reader.GetDateTime(6);
                        staff.ExitDate = reader.IsDBNull(7) ? null : reader.GetDateTime(7);

                        staff.Department = reader.GetString(8);
                        staff.Suitability = reader.GetBoolean(9);

                        _staffs.Add(staff);
                    }
                }
            }
            return _staffs;
        }

        [HttpPost("/api/[controller]/update")]
        public void UpdateStaff([FromBody] UpdateItem item)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "update staffs set name=@name where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@name", item.Text);
                    command.Parameters.AddWithValue("@id", item.Id);

                    command.ExecuteReader();
                }
            }
        }

        [HttpPost("/api/[controller]/delete")]
        public void DeleteStaff([FromBody] int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "delete from staffs where id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteReader();
                }
            }
        }
    }
}

