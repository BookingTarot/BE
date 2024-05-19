using BusinessObjects.DTOs;
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
    }
    public class UserRepository : IUserRepository
    {
        public User Login(string email, string password)
        {
            return UserDAO.Instance.Login(email, password);
        }

        public bool Register(RegisterRequest registerRequest)
        {
           return UserDAO.Instance.Register(registerRequest);
        }
    }
}
