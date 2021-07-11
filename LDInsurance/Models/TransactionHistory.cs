using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDInsurance.Models
{
    public class TransactionHistory
    {
        public int ID { get; set; }
        public int? AccountID { get; set; }
        public Account Account { get; set; }
        public int? InsuranceRegistrationID { get; set; }
        public InsuranceRegistration InsuranceRegistration { get; set; }
        public string Card { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
    }
}
