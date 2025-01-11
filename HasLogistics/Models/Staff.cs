using System;
namespace HasLogistics.Models
{
	public class Staff
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime EnterDate { get; set; }
	    public DateTime? ExitDate { get; set; }
        public string Department { get; set; }
	    public bool Suitability { get; set; }
	}
}

