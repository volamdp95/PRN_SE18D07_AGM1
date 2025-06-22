using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.DataAccess;
using NguyenVanCau_SE18D07_A01.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.Repositories.Implements
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer c) => CustomerDAO.Instance.Add(c);
        public void Delete(int id) => CustomerDAO.Instance.Delete(id);
        public List<Customer> GetAll() => CustomerDAO.Instance.GetAll();
        public Customer? GetByEmail(string email) => CustomerDAO.Instance.GetByEmail(email);
        public void Update(Customer c) => CustomerDAO.Instance.Update(c);
    }
}
