using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class CustomerDAO
    {
        private readonly TarotBookingContext context = null;
        private static CustomerDAO _instance = null;
        public static CustomerDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerDAO();
                }
                return _instance;
            }
        }

        public CustomerDAO()
        {
            context = new TarotBookingContext();
        }

        public async Task<List<Customer>> GetAll()
        {
            return  context.Customers.ToList();
        }
        public async Task<Customer> Get(int id)
        {
            return context.Customers.Where(x => x.UserId == id).FirstOrDefault();

        }
        public async Task<bool> Add(Customer customer)
        {
            try
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> Update(Customer customer)
        {
            try
            {
                var customerToUpdate = context.Customers.Find(customer.CustomerId);
                customerToUpdate.UserId = customer.UserId;
                customerToUpdate.Description = customer.Description;
                customerToUpdate.Status = customer.Status;
                context.Update(customerToUpdate);
                if (customerToUpdate == null)
                {
                    return false;
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var customer = context.Customers.Find(id);
                context.Customers.Remove(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
