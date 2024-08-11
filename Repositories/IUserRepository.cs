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
        public Task<User> Login(string email, string password);
        public Task<bool> RegisterUser(User user);
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<bool> Update(User user);
        public Task<bool> Delete(int id);
        public Task<User> Add(User user);
        public Task<bool> UpdateRole(int id, int roleId);
    }
    public class UserRepository : IUserRepository
    {
        public async Task<User> Add(User user)
        {
            return await UserDAO.Instance.CreateUser(user);
        }

        public async Task<bool> Delete(int id)
        {
            return await UserDAO.Instance.DeleteUser(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await UserDAO.Instance.GetUsers();
        }

        public async Task<User> GetById(int id)
        {
            return await UserDAO.Instance.GetUserById(id);
        }

        public async Task<User> Login(string email, string password)
        {
            return await UserDAO.Instance.Login(email, password);
        }

        public async Task<bool> RegisterUser(User user)
        {
           return await UserDAO.Instance.RegisterUser(user);
        }

        public async Task<bool> Update(User user)
        {
            return await UserDAO.Instance.UpdateUser(user);
        }

        public  async Task<bool> UpdateRole(int id, int roleId)
        {
            return await UserDAO.Instance.UpdateRole(id, roleId);
        }
    }
}
