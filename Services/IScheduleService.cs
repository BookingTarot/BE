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
        public bool AddSchedule(Schedule schedule);
        public bool UpdateSchedule(Schedule schedule);
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
        public bool AddSchedule(Schedule schedule)
        {
            return _repo.AddSchedule(schedule);
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

        public bool UpdateSchedule(Schedule schedule)
        {
            return _repo.UpdateSchedule(schedule);
        }
    }
}
