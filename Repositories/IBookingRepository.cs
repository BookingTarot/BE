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
        public List<Booking> GetBookings();
        public bool AddBooking(Booking booking);
        public bool DeleteBooking(int id);
        public bool UpdateBooking(Booking booking);
        public Booking GetBooking(int id);
    }
    public class BookingRepository : IBookingRepository
    {
        public bool AddBooking(Booking booking)
        {
            return BookingDAO.Instance.AddBooking(booking);
        }

        public bool DeleteBooking(int id)
        {
            return BookingDAO.Instance.DeleteBooking(id);
        }

        public Booking GetBooking(int id)
        {
            return BookingDAO.Instance.GetBookingById(id);
        }

        public List<Booking> GetBookings()
        {
            return BookingDAO.Instance.GetBookings();
        }

        public bool UpdateBooking(Booking booking)
        {
            return BookingDAO.Instance.UpdateBooking(booking);
        }
    }
}
