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
       public User Login(string email, string password);
        public bool RegisterCustomer(RegisterRequest registerRequest);
        public List<User> GetAll();
        public User GetById(int id);
        public bool Update(UserRequest user);
        public bool Delete(int id);
        public User Add(UserRequest request);
        public bool RegisterTarotReader(RegisterTarotReaderRequest registerRequest);
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

        public User Add(UserRequest request)
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
            return _repo.Add(user);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<User> GetAll()
        {
            return _repo.GetAll();
        }

        public User GetById(int id)
        {
            return _repo.GetById(id);
        }

        public User Login(string email, string password)
        {
            return _repo.Login(email, password);
        }

        public bool RegisterCustomer(RegisterRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Email) || string.IsNullOrWhiteSpace(registerRequest.Password))
            {
                throw new ArgumentException("Email and password are required.");
            }
            if (GetAll().Any(x => x.Email.Equals(registerRequest.Email)))
            {
                throw new Exception("A user with this email already exists.");
            }
            if (GetAll().Any(x => x.PhoneNumber.Equals(registerRequest.PhoneNumber)))
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
            var newUser = _repo.Add(user);
            

            Customer customer = new Customer();
            customer.UserId = newUser.UserId;
            customer.Description = registerRequest.Description;
            customer.Status = true;
            _customerReposity.Add(customer);
            return true;
        }

        public bool RegisterTarotReader(RegisterTarotReaderRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Email) || string.IsNullOrWhiteSpace(registerRequest.Password))
            {
                throw new ArgumentException("Email and password are required.");
            }
            if (GetAll().Any(x => x.Email.Equals(registerRequest.Email)))
            {
                throw new Exception("A user with this email already exists.");
            }
            if (GetAll().Any(x => x.PhoneNumber.Equals(registerRequest.PhoneNumber)))
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
            var newUser = _repo.Add(user);

            TarotReader tarotReader = new TarotReader();
            tarotReader.UserId = newUser.UserId;
            tarotReader.Introduction = registerRequest.Introduction;
            tarotReader.Description = registerRequest.Description;
            tarotReader.Experience = registerRequest.Experience;
           tarotReader.Kind = registerRequest.Kind;
            tarotReader.Image = registerRequest.Image;
            tarotReader.Status = true;
            _tarotReaderRepository.Add(tarotReader);
            return true;
            

    }

        public bool Update(UserRequest request)
        {
            var user = _repo.GetById(request.UserId);
            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.DateOfBirth = request.DateOfBirth;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Address = request.Address;
            user.Gender = request.Gender;


            return _repo.Update(user);
        }

      
    }
}
