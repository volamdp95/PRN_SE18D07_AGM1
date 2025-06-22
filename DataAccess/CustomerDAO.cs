using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.DataAccess
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static readonly object lockObj = new();
        private List<Customer> customers;

        private CustomerDAO()
        {
            customers = new List<Customer>
    {
        new Customer
        {
            CustomerID = 1,
            CustomerFullName = "Admin",
            Telephone = "01111111111",
            EmailAddress = "admin@FUMiniHotelSystem.com",
            Password = "@@abc123@@",
            CustomerStatus = 1,
            CustomerBirthday = new DateTime(1990, 1, 1)
        },
        new Customer
        {
            CustomerID = 2,
            CustomerFullName = "Nguyễn Văn A",
            Telephone = "0987654321",
            EmailAddress = "nva@gmail.com",
            Password = "123",
            CustomerStatus = 1,
            CustomerBirthday = new DateTime(2000, 5, 15)
        },
        new Customer
        {
            CustomerID = 3,
            CustomerFullName = "Trần Thị B",
            Telephone = "0912345678",
            EmailAddress = "ttb@yahoo.com",
            Password = "ttb456",
            CustomerStatus = 1,
            CustomerBirthday = new DateTime(1998, 11, 20)
        }
    };
        }

        public static CustomerDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new CustomerDAO();
                }
            }
        }

        public List<Customer> GetAll() => customers.Where(c => c.CustomerStatus == 1).ToList();
        public Customer? GetByEmail(string email) => customers.FirstOrDefault(c => c.EmailAddress == email);
        public void Add(Customer c) => customers.Add(c);
        public void Update(Customer c)
        {
            var exist = customers.FirstOrDefault(x => x.CustomerID == c.CustomerID);
            if (exist != null)
            {
                exist.CustomerFullName = c.CustomerFullName;
                exist.Telephone = c.Telephone;
                exist.EmailAddress = c.EmailAddress;
                exist.CustomerBirthday = c.CustomerBirthday;
                exist.Password = c.Password;
            }
        }
        public void Delete(int id)
        {
            var c = customers.FirstOrDefault(c => c.CustomerID == id);
            if (c != null) c.CustomerStatus = 2;
        }
    }

}
