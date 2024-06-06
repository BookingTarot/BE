using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IScheduleService
    {
        public bool AddSchedule(ScheduleRequest schedule);
        public bool UpdateSchedule(ScheduleRequest schedule);
        public bool Delete(int id);
        public List<Schedule> GetAll();
        public Schedule GetScheduleById(int id);
        public List<Schedule> GetSchedulesByTarotReaderId(int id);
    }

    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repo;
        public ScheduleService(IScheduleRepository repo)
        {
            _repo = repo;
        }
        public bool AddSchedule(ScheduleRequest schedule)
        { 
            var newSchedule = new Schedule
            {
                TarotReaderId = schedule.TarotReaderId,
                Date = schedule.Date,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                CustomerId = schedule.CustomerId,
                Status = schedule.Status
            };

            return _repo.AddSchedule(newSchedule);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<Schedule> GetAll()
        {
           return _repo.GetAll();
        }

        public Schedule GetScheduleById(int id)
        {
           return _repo.GetScheduleById(id);
        }

        public List<Schedule> GetSchedulesByTarotReaderId(int id)
        {
            return _repo.GetSchedulesByTarotReaderId(id);
        }

        public bool UpdateSchedule(ScheduleRequest  schedule)
        {
            var request = new Schedule
            {
                ScheduleId = schedule.ScheduleId,
                TarotReaderId = schedule.TarotReaderId,
                Date = schedule.Date,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                CustomerId = schedule.CustomerId,
                Status = schedule.Status
            };
            
            return _repo.UpdateSchedule(request);
        }
    }
}
