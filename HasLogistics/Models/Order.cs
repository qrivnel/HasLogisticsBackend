using System;
namespace HasLogistics.Models
{
	public class Order
	{
		public int Id { get; set; }
        public int ClientId { get; set; }
        public int TruckId { get; set; }
        public int TrailerId { get; set; }
        public int StaffId { get; set; }
        public int StuffId { get; set; }
        public int Distance { get; set; }
        public DateTime LoadDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TransportRevenue { get; set; }
    }
}

