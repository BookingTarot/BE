using BusinessObjects.Models;
using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerReposity
    {
        public List<Customer> getAll();
        public Customer getCustomerById(int id);
        public bool Add(Customer customer);
        public bool Delete(int id);
        public bool Update(Customer customer);
    }
    public class CustomerReposity : ICustomerReposity
    {
        public bool Add(Customer customer)
        {
            return CustomerDAO.Instance.Add(customer);
        }

        public bool Delete(int id)
        {
            return CustomerDAO.Instance.Delete(id);
        }

        public List<Customer> getAll()
        {
            return CustomerDAO.Instance.GetAll();
        }

        public Customer getCustomerById(int id)
        {
            return CustomerDAO.Instance.Get(id);
        }

        public bool Update(Customer customer)
        {
            return CustomerDAO.Instance.Update(customer);
        }
    }
}
