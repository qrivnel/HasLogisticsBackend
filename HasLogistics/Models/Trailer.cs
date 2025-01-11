using System;
namespace HasLogistics.Models
{
	public class Trailer
	{
		public int Id { get; set; }
        public string LastStuffKind { get; set; }
        public string Plate { get; set; }
        public bool IsClean { get; set; }
        public string Type { get; set; }
        public DateTime LastInspectionDate { get; set; }
        public bool Suitability { get; set; }
    }
}

