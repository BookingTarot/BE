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
        public bool Update(User user);
        public bool Delete(int id);
        public bool Add(User user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool Add(User user)
        {
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

        public bool Update(User user)
        {
            return _repo.Update(user);
        }
    }
}
