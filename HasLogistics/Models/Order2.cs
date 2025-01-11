using System;
namespace HasLogistics.Models
{
	public class Order2
	{
        public int Id { get; set; }
        public int Distance { get; set; }
        public DateTime LoadDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TransportRevenue { get; set; }
        public string StaffName { get; set; }
        public string CompanyName { get; set; }
        public string TruckPlate { get; set; }
        public string TrailerPlate { get; set; }
        public string StuffName { get; set; }
    }
}

