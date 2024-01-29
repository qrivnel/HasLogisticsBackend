using System;
using HasLogistics.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;


namespace HasLogistics.Controllers
{
    [Route("/api/[controller]")]
	public class OrdersController
	{
        public List<Order> _orders = new List<Order>();
        public List<Order2> _orders2 = new List<Order2>();

        [HttpGet]
        public List<Order> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();

                string commandString2 = "select * from orders";

                using (NpgsqlCommand command = new NpgsqlCommand(commandString2, connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.Id = reader.GetInt16(0);
                        order.TruckId = reader.GetInt16(1);
                        order.TrailerId = reader.GetInt16(2);
                        order.StaffId = reader.GetInt16(3);
                        order.StuffId = reader.GetInt16(4);
                        order.ClientId = reader.GetInt16(5);
                        order.Distance = reader.GetInt16(6);
                        order.LoadDate = reader.GetDateTime(7);
                        order.DeliveryDate = reader.GetDateTime(8);
                        order.TransportCost = reader.GetDecimal(9);
                        order.TransportRevenue = reader.GetDecimal(10);
                        _orders.Add(order);
                    }
                }
                    return _orders;
            }
        }

        
        [HttpPost]
        public Order Post([FromBody] Order o)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Database.connectionString))
            {
                connection.Open();
                string commandString = "insert into orders (truckid, trailerid, staffid, stuffid, clientid, distance, loaddate, deliverydate, transportcost, transportrevenue) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)";
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@p1", o.TruckId);
                    command.Parameters.AddWithValue("@p2", o.TrailerId);
                    command.Parameters.AddWithValue("@p3", o.StaffId);
                    command.Parameters.AddWithValue("@p4", o.StuffId);
                    command.Parameters.AddWithValue("@p5", o.ClientId);
                    command.Parameters.AddWithValue("@p6", o.Distance);
                    command.Parameters.AddWithValue("@p7", o.LoadDate);
                    command.Parameters.AddWithValue("@p8", o.DeliveryDate);
                    command.Parameters.AddWithValue("@p9", o.TransportCost);
                    command.Parameters.AddWithValue("@p10", o.TransportRevenue);
                    NpgsqlDataReader reader = command.ExecuteReader();
                }
            }
            return o;
        }
    }
}

