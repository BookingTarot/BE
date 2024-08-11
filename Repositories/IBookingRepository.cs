using BusinessObjects.DTOs.Response;
using BusinessObjects.Models;
using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingRepository
    {
        public Task<List<Booking>> GetBookings();
        public Task<bool> AddBooking(Booking booking);
        public Task<bool> DeleteBooking(int id);
        public Task<bool> UpdateBooking(Booking booking);
        public Task<Booking> GetBooking(int id);
    }
    public class BookingRepository : IBookingRepository
    {
        public async Task<bool> AddBooking(Booking booking)
        {
            return await BookingDAO.Instance.AddBooking(booking);
        }

        public async Task<bool> DeleteBooking(int id)
        {
            return await BookingDAO.Instance.DeleteBooking(id);
        }

        public async Task<Booking> GetBooking(int id)
        {
            return await BookingDAO.Instance.GetBookingById(id);
        }

        public async Task<List<Booking>> GetBookings()
        {
            return await BookingDAO.Instance.GetBookings();
        }

        public async Task<bool> UpdateBooking(Booking booking)
        {
            return await BookingDAO.Instance.UpdateBooking(booking);
        }
    }
}
