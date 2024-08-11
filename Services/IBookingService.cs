using BusinessObjects.DTOs.Request;
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
        public Task<List<BookingResponse>> GetBookings(GetListBookingRequest request);
        public Task<bool> AddBooking(BookingRequest booking);
        public Task<bool> DeleteBooking(int id);
        public Task<bool> UpdateBooking(BookingRequest booking);
        public Task<BookingResponse> GetBooking(int id);
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

        public async Task<List<BookingResponse>> GetBookings(GetListBookingRequest request)
        {
            var bookings =  (await _repo.GetBookings()).AsQueryable();
            if(request.BookingId > 0)
            {
                bookings = bookings.Where(x => x.BookingId == request.BookingId);
            }
            if (request.CustomerId > 0)
            {
                bookings = bookings.Where(x => x.CustomerId == request.CustomerId);
            }
            if (request.TarotReaderId > 0)
            {
                bookings = bookings.Where(x => x.TarotReaderId == request.TarotReaderId);
            }
            if (request.ScheduleId > 0)
            {
                bookings = bookings.Where(x => x.ScheduleId == request.ScheduleId);
            }
            if (request.SessionTypeId > 0)
            {
                bookings = bookings.Where(x => x.SessionTypeId == request.SessionTypeId);
            }
            
            
            var bookingResponses = new List<BookingResponse>();
            foreach (var booking in bookings)
            {
                BookingResponse bookingResponse = new BookingResponse
                {
                    BookingId = booking.BookingId,
                    CustomerId = booking.CustomerId,
                    TarotReaderId = booking.TarotReaderId,
                    TarotUserId = booking.TarotReader.UserId,
                    ScheduleId = booking.ScheduleId,
                    SessionTypeId = booking.SessionTypeId,
                    TarotReaderName = booking.TarotReader.User.FirstName + " " + booking.TarotReader.User.LastName,
                    CustomerName = booking.Customer.User.FirstName + " " + booking.Customer.User.LastName,
                    Age = DateTime.Now.Year - booking.Customer.User.DateOfBirth.Value.Year,
                    Gender = booking.Customer.User.Gender,
                    PhoneNumber = booking.Customer.User.PhoneNumber,
                    Date = booking.Date.Value,
                    StartTime = booking.Schedule.StartTime.Value,
                    EndTime = booking.Schedule.EndTime.Value,
                    SessionTypeName = booking.SessionType.Name,
                    Amount = booking.Amount.Value,
                    Description = booking.Description,
                    Status = booking.Status.Value,
                    LinkMeet = booking.LinkMeet

                };
                bookingResponses.Add(bookingResponse);
            }
            return bookingResponses;
        }

        public async Task<bool> AddBooking(BookingRequest booking)
        {

           
            
                Booking newBooking = new Booking
                {
                    
                    CustomerId = booking.CustomerId,
                    TarotReaderId = booking.TarotReaderId,
                    Date = DateTime.Now,
                    Amount = booking.Amount,
                    Status = false,
                    Description = booking.Description,
                    ScheduleId = booking.ScheduleId,
                    SessionTypeId = booking.SessionTypeId
                    //LinkMeet = booking.LinkMeet
                };
                return await _repo.AddBooking(newBooking);
            
            
        }

        public async Task<bool> DeleteBooking(int id)
        {
            return await _repo.DeleteBooking(id);
        }

        public  async Task<bool> UpdateBooking(BookingRequest booking)
        {
            var bookingToUpdate = await _repo.GetBooking(booking.BookingId);
            if (bookingToUpdate == null)
            {
                return false;
            }
            bookingToUpdate.CustomerId = booking.CustomerId;
            bookingToUpdate.TarotReaderId = booking.TarotReaderId;
            bookingToUpdate.Date = booking.Date;
            bookingToUpdate.Amount = booking.Amount;
            bookingToUpdate.Status = booking.Status;
            bookingToUpdate.Description = booking.Description;
            bookingToUpdate.ScheduleId = booking.ScheduleId;
            bookingToUpdate.SessionTypeId = booking.SessionTypeId;
            bookingToUpdate.LinkMeet = booking.LinkMeet;

            return await _repo.UpdateBooking(bookingToUpdate);
        }

        public async Task<BookingResponse> GetBooking(int id)
        {
            var booking = await _repo.GetBooking(id);
            BookingResponse bookingResponse = new BookingResponse
            {
                BookingId = booking.BookingId,
                CustomerId = booking.CustomerId,
                TarotReaderId = booking.TarotReaderId,
                TarotUserId = booking.TarotReader.UserId,
                ScheduleId = booking.ScheduleId,
                SessionTypeId = booking.SessionTypeId,
                TarotReaderName = booking.TarotReader.User.FirstName + " " + booking.TarotReader.User.LastName,
                CustomerName = booking.Customer.User.FirstName + " " + booking.Customer.User.LastName,
                Age = DateTime.Now.Year - booking.Customer.User.DateOfBirth.Value.Year,
                Gender = booking.Customer.User.Gender,
                PhoneNumber = booking.Customer.User.PhoneNumber,
                Date = booking.Date.Value,
                StartTime = booking.Schedule.StartTime.Value,
                EndTime = booking.Schedule.EndTime.Value,
                SessionTypeName = booking.SessionType.Name,
                Amount = booking.Amount.Value,
                Description = booking.Description,
                Status = booking.Status.Value,
                LinkMeet = booking.LinkMeet
                

            };
            return bookingResponse;
        }
    }
}
