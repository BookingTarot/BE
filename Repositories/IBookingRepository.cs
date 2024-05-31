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
    }
    public class BookingRepository : IBookingRepository
    {
        public List<Booking> GetBookings()
        {
            return BookingDAO.Instance.GetBookings();
        }
    }
}
