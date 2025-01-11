using System;
namespace HasLogistics.Models
{
	public class Truck
	{
		public int Id { get; set; }
		public int StaffId { get; set; }
		public string Plate { get; set; }
        public DateTime LastInspectionDate { get; set; }
        public bool Suitability { get; set; }
    }
}

