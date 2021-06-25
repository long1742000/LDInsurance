using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDInsurance.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool Status { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Testimonial> Testimonials { get; set; }
    }
}
