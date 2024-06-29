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
        public List<Customer> getAll();
        public Customer getCustomerById(int id);
        public bool Add(CustomerRequest customer);
        public bool Delete(int id);
        public bool Update(CustomerRequest customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerReposity _repo;

        public CustomerService(ICustomerReposity repo)
        {
            _repo = repo;
        }

        public bool Add(CustomerRequest request)
        {
            var customer = new Customer();
            customer.UserId = request.UserId;
            customer.Description = request.Description;
            customer.Status = request.Status;
            return _repo.Add(customer);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<Customer> getAll()
        {
            return _repo.getAll();
        }

        public Customer getCustomerById(int id)
        {
            return _repo.getCustomerById(id);
        }

        public bool Update(CustomerRequest customer)
        {
            var customerUpdate = new Customer();
            customerUpdate.CustomerId = customer.CustomerId;
            customerUpdate.UserId = customer.UserId;
            customerUpdate.Description = customer.Description;
            customerUpdate.Status = customer.Status;
            
            return _repo.Update(customerUpdate);
        }

       
    }
}
