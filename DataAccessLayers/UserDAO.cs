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
                return true;
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
                    TarotReader = x.TarotReader != null ? new TarotReader
                    {
                        TarotReaderId = x.TarotReader.TarotReaderId,
                    } : null

                })
                .FirstOrDefault(x => x.Email.Equals(email)
                                && x.Password.Equals(password)
                                && x.IsActive == true);
        }

        public bool Register(RegisterRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Email) || string.IsNullOrWhiteSpace(registerRequest.Password))
            {
                throw new ArgumentException("Email and password are required.");
            }
            if (GetUsers().Any(x => x.Email.Equals(registerRequest.Email)))
            {
                throw new Exception("A user with this email already exists.");
            }
            if(GetUsers().Any(x => x.PhoneNumber.Equals(registerRequest.PhoneNumber)))
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
            context.Users.Add(user);
            
            return context.SaveChanges() > 0;
        }
        public bool CreateUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }   
    }
}
