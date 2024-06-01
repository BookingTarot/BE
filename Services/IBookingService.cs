﻿using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingService
    {
        public List<BookingResponse> GetBookings();
        public bool AddBooking(BookingRequest booking);
    }
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;
        private readonly IScheduleRepository _scheduleRepo;
        private readonly ITarotReaderRepository _tarotReaderRepo;
        public BookingService(IBookingRepository repo, IScheduleRepository scheduleRepo, ITarotReaderRepository tarotReaderRepo)
        {
            _repo = repo;
            _scheduleRepo = scheduleRepo;
            _tarotReaderRepo = tarotReaderRepo;
        }

        public List<BookingResponse> GetBookings()
        {
            var bookings = _repo.GetBookings();
            List<BookingResponse> bookingResponses = new List<BookingResponse>();
            foreach (var booking in bookings)
            {
                BookingResponse bookingResponse = new BookingResponse
                {
                    BookingId = booking.BookingId,
                    CustomerName = booking.Customer.User.FirstName + " " + booking.Customer.User.LastName,
                    Age = DateTime.Now.Year - booking.Customer.User.DateOfBirth.Value.Year,
                    Gender = booking.Customer.User.Gender,
                    PhoneNumber = booking.Customer.User.PhoneNumber,
                    Date = booking.Date.Value,
                    StartTime = booking.Schedule.StartTime.Value,
                    EndTime = booking.Schedule.EndTime.Value,
                    SessionTypeName = booking.SessionType.Name,
                    Status = booking.Status == true ? "Confirmed" : "Pending"

                };
                bookingResponses.Add(bookingResponse);
            }
            return bookingResponses;
        }

        public bool AddBooking(BookingRequest booking)
        {
            
            Schedule schedule = new Schedule
            {
               
                TarotReaderId = booking.TarotReaderId,
                Date = booking.BookDate,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                CustomerId = booking.CustomerId
            };
            if (_scheduleRepo.AddSchedule(schedule))
            {
                Booking newBooking = new Booking
                {
                    
                    CustomerId = booking.CustomerId,
                    TarotReaderId = booking.TarotReaderId,
                    Date = DateTime.Now,
                    Amount = booking.Amount,
                    Status = true,
                    Description = booking.Description,
                    ScheduleId = schedule.ScheduleId,
                    SessionTypeId = booking.SessionTypeId
                };
                return _repo.AddBooking(newBooking);
            }
            return false;
        }
    }
}