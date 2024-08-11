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
        public Task<bool> AddSchedule(ScheduleRequest schedule);
        public Task<bool> UpdateSchedule(ScheduleRequest schedule);
        public Task<bool> Delete(int id);
        public Task<List<Schedule>> GetAll();
        public Task<Schedule> GetScheduleById(int id);
        public Task<List<Schedule>> GetSchedulesByTarotReaderId(int id);
    }

    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repo;
        public ScheduleService(IScheduleRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddSchedule(ScheduleRequest schedule)
        { 
            var newSchedule = new Schedule
            {
                TarotReaderId = schedule.TarotReaderId,
                Date = schedule.Date,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                Status = schedule.Status
            };

            return await _repo.AddSchedule(newSchedule);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<List<Schedule>> GetAll()
        {
           return await _repo.GetAll();
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
           return await _repo.GetScheduleById(id);
        }

        public async Task<List<Schedule>> GetSchedulesByTarotReaderId(int id)
        {
            return await _repo.GetSchedulesByTarotReaderId(id);
        }

        public async Task<bool> UpdateSchedule(ScheduleRequest  schedule)
        {
            var request = new Schedule
            {
                ScheduleId = schedule.ScheduleId,
                TarotReaderId = schedule.TarotReaderId,
                Date = schedule.Date,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                Status = schedule.Status
            };
            
            return await _repo.UpdateSchedule(request);
        }
    }
}
