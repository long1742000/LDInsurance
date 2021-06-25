using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDInsurance.Models
{
    public class Testimonial
    {
        public int ID { get; set; }
        public int? AccountID { get; set; }
        public Account Account { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
