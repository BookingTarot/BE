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
    public interface IUserService
    {
       public Task<User> Login(string email, string password);
        public Task<bool> RegisterCustomer(RegisterRequest registerRequest);
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<bool> Update(UserRequest user);
        public Task<bool> Delete(int id);
        public Task<User> Add(UserRequest request);
        public Task<bool> RegisterTarotReader(RegisterTarotReaderRequest registerRequest);

        public Task<bool> UpdateRole(int id, int roleId);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly ICustomerReposity _customerReposity;
        private readonly ITarotReaderRepository _tarotReaderRepository;
        public UserService(IUserRepository repo, ICustomerReposity customerReposity, ITarotReaderRepository tarotReaderRepository)
        {
            _repo = repo;
            _customerReposity = customerReposity;
            _tarotReaderRepository = tarotReaderRepository;
        }

        public async Task<User> Add(UserRequest request)
        {
            var user = new User
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Email = request.Email,
                Password = request.Password,
                Address = request.Address
            };
            return await _repo.Add(user);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<User> Login(string email, string password)
        {
            return await _repo.Login(email, password);
        }

        public async Task<bool> RegisterCustomer(RegisterRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Email) || string.IsNullOrWhiteSpace(registerRequest.Password))
            {
                throw new ArgumentException("Email and password are required.");
            }
            var users = await _repo.GetAll();
            if (users.Any(x => x.Email.Equals(registerRequest.Email)))
            {
                throw new Exception("A user with this email already exists.");
            }
            if (users.Any(x => x.PhoneNumber.Equals(registerRequest.PhoneNumber)))
            {
                throw new Exception("A user with this phone number already exists.");
            }
            User user = new User();
            user.LastName = registerRequest.LastName;
            user.FirstName = registerRequest.FirstName;
            user.DateOfBirth = registerRequest.DateOfBirth;
            user.PhoneNumber = registerRequest.PhoneNumber;
            user.Gender = registerRequest.Gender;
            user.Email = registerRequest.Email;
            user.Password = registerRequest.Password;
            user.Address = registerRequest.Address;
            user.IsActive = true;
            user.RoleId = 2;
            var newUser = await _repo.Add(user);
            

            Customer customer = new Customer();
            customer.UserId = newUser.UserId;
            customer.Description = registerRequest.Description;
            customer.Status = true;
            await _customerReposity.Add(customer);
            return true;
        }

        public async Task<bool> RegisterTarotReader(RegisterTarotReaderRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Email) || string.IsNullOrWhiteSpace(registerRequest.Password))
            {
                throw new ArgumentException("Email and password are required.");
            }
            var users = await _repo.GetAll();
            if (users.Any(x => x.Email.Equals(registerRequest.Email)))
            {
                throw new Exception("A user with this email already exists.");
            }
            if (users.Any(x => x.PhoneNumber.Equals(registerRequest.PhoneNumber)))
            {
                throw new Exception("A user with this phone number already exists.");
            }
            User user = new User();
            user.LastName = registerRequest.LastName;
            user.FirstName = registerRequest.FirstName;
            user.DateOfBirth = registerRequest.DateOfBirth;
            user.PhoneNumber = registerRequest.PhoneNumber;
            user.Gender = registerRequest.Gender;
            user.Email = registerRequest.Email;
            user.Password = registerRequest.Password;
            user.Address = registerRequest.Address;
            user.IsActive = true;
            user.RoleId = 3;
            var newUser = await _repo.Add(user);

            TarotReader tarotReader = new TarotReader();
            tarotReader.UserId = newUser.UserId;
            tarotReader.Introduction = registerRequest.Introduction;
            tarotReader.Description = registerRequest.Description;
            tarotReader.Experience = registerRequest.Experience;
           tarotReader.Kind = registerRequest.Kind;
            tarotReader.Image = registerRequest.Image;
            tarotReader.Status = true;
            await _tarotReaderRepository.Add(tarotReader);
            return true;
            

    }

        public async Task<bool> Update(UserRequest request)
        {
            var user = await _repo.GetById(request.UserId);
            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.DateOfBirth = request.DateOfBirth;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Address = request.Address;
            user.Gender = request.Gender;


            return await _repo.Update(user);
        }

        public async Task<bool> UpdateRole(int id, int roleId)
        {
            return await _repo.UpdateRole(id, roleId);
        }
    }
}
