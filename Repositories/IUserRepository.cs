using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        public User Login(string email, string password);
        public bool Register(RegisterRequest registerRequest);
        public List<User> GetAll();
        public User GetById(int id);
        public bool Update(User user);
        public bool Delete(int id);
        public bool Add(User user);
    }
    public class UserRepository : IUserRepository
    {
        public bool Add(User user)
        {
            return UserDAO.Instance.CreateUser(user);
        }

        public bool Delete(int id)
        {
            return UserDAO.Instance.DeleteUser(id);
        }

        public List<User> GetAll()
        {
            return UserDAO.Instance.GetUsers();
        }

        public User GetById(int id)
        {
            return UserDAO.Instance.GetUserById(id);
        }

        public User Login(string email, string password)
        {
            return UserDAO.Instance.Login(email, password);
        }

        public bool Register(RegisterRequest registerRequest)
        {
           return UserDAO.Instance.Register(registerRequest);
        }

        public bool Update(User user)
        {
            return UserDAO.Instance.UpdateUser(user);
        }
    }
}
