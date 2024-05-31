using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class ScheduleDAO
    {
        private readonly TarotBookingContext context = null;
        private static ScheduleDAO _instance = null;
        public static ScheduleDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScheduleDAO();
                }
                return _instance;
            }
        }

        public ScheduleDAO()
        {
            context = new TarotBookingContext();
        }

        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                context.Schedules.Add(schedule);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
