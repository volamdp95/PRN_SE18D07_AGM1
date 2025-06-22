using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer? GetByEmail(string email);
        void Add(Customer c);
        void Update(Customer c);
        void Delete(int id);
    }

}
