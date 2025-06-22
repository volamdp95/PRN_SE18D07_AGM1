using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.BusinessObjects.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public int CustomerStatus { get; set; } // 1: Active, 2: Deleted
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{CustomerFullName} ({EmailAddress})";
        }
    }
}
