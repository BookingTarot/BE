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
        public Task<List<Customer>> getAll();
        public Task<Customer> getCustomerById(int id);
        public Task<bool> Add(Customer customer);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Customer customer);
    }
    public class CustomerReposity : ICustomerReposity
    {
        public async Task<bool> Add(Customer customer)
        {
            return await CustomerDAO.Instance.Add(customer);
        }

        public async Task<bool> Delete(int id)
        {
            return await CustomerDAO.Instance.Delete(id);
        }

        public async Task<List<Customer>> getAll()
        {
            return await CustomerDAO.Instance.GetAll();
        }

        public async Task<Customer> getCustomerById(int id)
        {
            return await CustomerDAO.Instance.Get(id);
        }

        public async Task<bool> Update(Customer customer)
        {
            return await CustomerDAO.Instance.Update(customer);
        }
    }
}
