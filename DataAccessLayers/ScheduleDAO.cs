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
        public async Task<List<Schedule>> GetAll()
        {
            return context.Schedules.ToList();
        }
        public async Task<Schedule> GetScheduleById(int id)
        {
            return context.Schedules.Find(id);
        }
        public async Task<List<Schedule>> GetSchedulesByTarotReaderId(int id)
        {
            return context.Schedules.Where(s => s.TarotReaderId == id).ToList();
        }
        public async Task<bool> UpdateSchedule(Schedule schedule)
        {
            try
            {
                var scheduleToUpdate = context.Schedules.Find(schedule.ScheduleId);
                scheduleToUpdate.Date = schedule.Date;
                scheduleToUpdate.StartTime = schedule.StartTime;
                scheduleToUpdate.EndTime = schedule.EndTime;
                scheduleToUpdate.TarotReaderId = schedule.TarotReaderId;
                scheduleToUpdate.Status = schedule.Status;
                context.Schedules.Update(scheduleToUpdate);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
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
        public async Task<bool> AddSchedule(Schedule schedule)
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
