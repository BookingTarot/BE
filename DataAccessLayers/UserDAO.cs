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
        public List<User> GetUsers()
        {
            return context.Users.Where(x => x.IsActive == true)
                //.Include(tr => tr.TarotReader)
                //.Include(r => r.Role)
                .ToList();
        }

        public User Login(string email, string password)
        {
            return context.Users
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
    }
}
