﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class BookingDAO
    {
        private readonly TarotBookingContext context = null;
        private static BookingDAO _instance = null;
        public static BookingDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookingDAO();
                }
                return _instance;
            }
        }

        public BookingDAO()
        {
            context = new TarotBookingContext();
        }
        public  Booking GetBookingById(int id)
        {
            return context.Bookings.
                Where(a => a.BookingId == id)
           .Select(b => new Booking
            {
                BookingId = b.BookingId,
                CustomerId = b.CustomerId,
                TarotReaderId = b.TarotReaderId,
                Date = b.Date,
                Amount = b.Amount,
                Status = b.Status,
                Description = b.Description,
                ScheduleId = b.ScheduleId,
                SessionTypeId = b.SessionTypeId,
                TarotReader = new TarotReader
                {
                    TarotReaderId = b.TarotReader.TarotReaderId,
                    UserId = b.TarotReader.UserId,
                    User = new User
                    {
                        UserId = b.TarotReader.User.UserId,
                        LastName = b.TarotReader.User.LastName,
                        FirstName = b.TarotReader.User.FirstName
                    }

                },
                Customer = new Customer
                {
                    CustomerId = b.Customer.CustomerId,
                    UserId = b.Customer.UserId,
                    User = new User
                    {
                        UserId = b.Customer.User.UserId,
                        LastName = b.Customer.User.LastName,
                        FirstName = b.Customer.User.FirstName,
                        DateOfBirth = b.Customer.User.DateOfBirth,
                        Gender = b.Customer.User.Gender,
                        PhoneNumber = b.Customer.User.PhoneNumber
                    }
                },
                SessionType = new SessionType
                {
                    SessionTypeId = b.SessionType.SessionTypeId,
                    Name = b.SessionType.Name,
                    Description = b.SessionType.Description,
                    Price = b.SessionType.Price,
                    Status = b.SessionType.Status,
                    Duration = b.SessionType.Duration
                },
                Schedule = new Schedule
                {
                    ScheduleId = b.Schedule.ScheduleId,
                    Date = b.Schedule.Date,
                    StartTime = b.Schedule.StartTime,
                    EndTime = b.Schedule.EndTime,
                    TarotReader = new TarotReader
                    {
                        TarotReaderId = b.Schedule.TarotReader.TarotReaderId,
                        SessionTypes = b.TarotReader.SessionTypes.Select(st => new SessionType
                        {
                            SessionTypeId = st.SessionTypeId,
                            Name = st.Name,
                            Description = st.Description,
                            Price = st.Price,
                            Status = st.Status,
                            Duration = st.Duration
                        }).ToList(),
                    },
                },


            }).FirstOrDefault();
        }

        public List<Booking> GetBookings()
        {
            return context.Bookings
                .Select(b => new Booking
                {
                    BookingId = b.BookingId,
                    CustomerId = b.CustomerId,
                    TarotReaderId = b.TarotReaderId,
                    Date = b.Date,
                    Amount = b.Amount,
                    Status = b.Status,
                    Description = b.Description,
                    ScheduleId = b.ScheduleId,
                    SessionTypeId = b.SessionTypeId,
                    TarotReader = new TarotReader
                    {
                        TarotReaderId = b.TarotReader.TarotReaderId,
                        UserId = b.TarotReader.UserId,
                        User = new User
                        {
                            UserId = b.TarotReader.User.UserId,
                            LastName = b.TarotReader.User.LastName,
                            FirstName = b.TarotReader.User.FirstName
                        }
                    },
                    Customer = new Customer
                    {
                        CustomerId = b.Customer.CustomerId,
                        UserId = b.Customer.UserId,
                        User = new User
                        {
                            UserId = b.Customer.User.UserId,
                            LastName = b.Customer.User.LastName,
                            FirstName = b.Customer.User.FirstName,
                            DateOfBirth = b.Customer.User.DateOfBirth,
                            Gender = b.Customer.User.Gender,
                            PhoneNumber = b.Customer.User.PhoneNumber

                            
                        }
                    },
                    SessionType = new SessionType
                    {
                        SessionTypeId = b.SessionType.SessionTypeId,
                        Name = b.SessionType.Name,
                        Description = b.SessionType.Description,
                        Price = b.SessionType.Price,
                        Status = b.SessionType.Status,
                        Duration = b.SessionType.Duration
                    },
                    Schedule = new Schedule
                    {
                        ScheduleId = b.Schedule.ScheduleId,
                        Date = b.Schedule.Date,
                        StartTime = b.Schedule.StartTime,
                        EndTime = b.Schedule.EndTime,
                        TarotReader = new TarotReader
                        {
                            TarotReaderId = b.Schedule.TarotReader.TarotReaderId,
                            SessionTypes = b.TarotReader.SessionTypes.Select(st => new SessionType
                            {
                                SessionTypeId = st.SessionTypeId,
                                Name = st.Name,
                                Description = st.Description,
                                Price = st.Price,
                                Status = st.Status,
                                Duration = st.Duration
                            }).ToList(),
                        },
                    },
                    
                    
                }).ToList();
        }

        public bool AddBooking(Booking booking)
        {
            try
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                var bookingToUpdate = context.Bookings.Find(booking.BookingId);
                if (bookingToUpdate != null)
                {
                    bookingToUpdate.CustomerId = booking.CustomerId;
                    bookingToUpdate.TarotReaderId = booking.TarotReaderId;
                    bookingToUpdate.Date = booking.Date;
                    bookingToUpdate.Amount = booking.Amount;
                    bookingToUpdate.Status = booking.Status;
                    bookingToUpdate.Description = booking.Description;
                    bookingToUpdate.ScheduleId = booking.ScheduleId;
                    bookingToUpdate.SessionTypeId = booking.SessionTypeId;
                    
                    return context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBooking(int id)
        {
            try
            {
                var booking = context.Bookings.Find(id);
                if (booking != null)
                {
                    context.Bookings.Remove(booking);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
