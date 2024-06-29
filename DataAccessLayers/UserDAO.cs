using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class UserDAO
    {
        private readonly TarotBookingContext context = null;
        private static UserDAO _instance = null;
        public static UserDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDAO();
                }
                return _instance;
            }

        }
        public UserDAO()
        {
            context = new TarotBookingContext();
        }
        public User GetUserById(int id)
        {
            return context.Users.Where(u => u.UserId == id).FirstOrDefault();
        }
        public bool DeleteUser(int id)
        {
            try
            {
                var user = context.Users.Find(id);
                user.IsActive = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                var userToUpdate = context.Users.Find(user.UserId);
                userToUpdate.LastName = user.LastName;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.DateOfBirth = user.DateOfBirth;
                userToUpdate.PhoneNumber = user.PhoneNumber;
                userToUpdate.Gender = user.Gender;
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                userToUpdate.Address = user.Address;
                userToUpdate.IsActive = user.IsActive;
                userToUpdate.RoleId = user.RoleId;
                context.SaveChanges();
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<User> GetUsers()
        {
            return context.Users.Where(x => x.IsActive == true)
                //.Include(tr => tr.TarotReader)
                //.Include(r => r.Role)
                .ToList();
        }

        public User Login(string email, string password)
        {
            return context.Users.Select(
                x => new User
                {
                    UserId = x.UserId,
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    DateOfBirth = x.DateOfBirth,
                    PhoneNumber = x.PhoneNumber,
                    Gender = x.Gender,
                    Email = x.Email,
                    Password = x.Password,
                    Address = x.Address,
                    IsActive = x.IsActive,
                    RoleId = x.RoleId,
                    Customer = x.Customer != null ? new Customer
                    {
                        CustomerId = x.Customer.CustomerId,
                    } : null,
                    TarotReader = x.TarotReader != null ? new TarotReader
                    {
                        TarotReaderId = x.TarotReader.TarotReaderId,
                    } : null
                    
                   

                })
                .FirstOrDefault(x => x.Email.Equals(email)
                                && x.Password.Equals(password)
                                && x.IsActive == true);
                   
        }

        public bool RegisterUser(User user)
        {
            
            context.Users.Add(user);
            return context.SaveChanges() > 0;
        }
        public User CreateUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }   
    }
}
