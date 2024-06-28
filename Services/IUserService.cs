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
        public bool Register(RegisterRequest registerRequest);
        public List<User> GetAll();
        public User GetById(int id);
        public bool Update(UserRequest user);
        public bool Delete(int id);
        public bool Add(RegisterRequest request);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool Add(RegisterRequest request)
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

        public bool Register(RegisterRequest registerRequest)
        {
            return _repo.Register(registerRequest);
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
