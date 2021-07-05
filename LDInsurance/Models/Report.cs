using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDInsurance.Models
{
    public class Report
    {
        public int ID { get; set; }
        public int? AccountID { get; set; }
        public Account Account { get; set; }
        public int? VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public int ClaimAmount { get; set; }
        public bool Status { get; set; }
    }
}
