using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDInsurance.Models
{
    public class Expense
    {
        public int ID { get; set; }
        public int? InsuranceRegistrationID { get; set; }
        public InsuranceRegistration InsuranceRegistration { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
    }
}
