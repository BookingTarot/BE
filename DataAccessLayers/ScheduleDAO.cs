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
        public List<Schedule> GetAll()
        {
            return context.Schedules.ToList();
        }
        public Schedule GetScheduleById(int id)
        {
            return context.Schedules.Find(id);
        }
        public List<Schedule> GetSchedulesByTarotReaderId(int id)
        {
            return context.Schedules.Where(s => s.TarotReaderId == id).ToList();
        }
        public bool UpdateSchedule(Schedule schedule)
        {
            try
            {
                var scheduleToUpdate = context.Schedules.Find(schedule.ScheduleId);
                scheduleToUpdate.Date = schedule.Date;
                scheduleToUpdate.StartTime = schedule.StartTime;
                scheduleToUpdate.EndTime = schedule.EndTime;
                scheduleToUpdate.TarotReaderId = schedule.TarotReaderId;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var scheduleToDelete = context.Schedules.Find(id);
                context.Schedules.Remove(scheduleToDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
