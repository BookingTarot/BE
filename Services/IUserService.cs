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
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public List<User> GetAll()
        {
            return _repo.GetAll();
        }

        public User Login(string email, string password)
        {
            return _repo.Login(email, password);
        }

        public bool Register(RegisterRequest registerRequest)
        {
            return _repo.Register(registerRequest);
        }

        
    }
}
