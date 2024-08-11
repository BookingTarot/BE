using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> getAll();
        public Task<Customer> getCustomerById(int id);
        public Task<bool> Add(CustomerRequest customer);
        public Task<bool> Delete(int id);
        public Task<bool> Update(CustomerRequest customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerReposity _repo;

        public CustomerService(ICustomerReposity repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(CustomerRequest request)
        {
            var customer = new Customer();
            customer.UserId = request.UserId;
            customer.Description = request.Description;
            customer.Status = request.Status;
            return await _repo.Add(customer);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<List<Customer>> getAll()
        {
            return await _repo.getAll();
        }

        public async Task<Customer> getCustomerById(int id)
        {
            return await _repo.getCustomerById(id);
        }

        public async Task<bool> Update(CustomerRequest customer)
        {
            var customerUpdate = new Customer();
            customerUpdate.CustomerId = customer.CustomerId;
            customerUpdate.UserId = customer.UserId;
            customerUpdate.Description = customer.Description;
            customerUpdate.Status = customer.Status;
            
            return await _repo.Update(customerUpdate);
        }

       
    }
}
