using BusinessObjects.DTOs;
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
        public List<Booking> GetBookings();
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

        public List<Booking> GetBookings()
        {
            return _repo.GetBookings();
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
                    ScheduleId = schedule.ScheduleId
                };
                return _repo.AddBooking(newBooking);
            }
            return false;
        }
    }
}
