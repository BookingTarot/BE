using BusinessObjects.Models;
using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IScheduleRepository
    {
        public Task<bool> AddSchedule(Schedule schedule);
        public Task<bool> UpdateSchedule(Schedule schedule);
        public Task<bool> Delete(int id);
        public Task<List<Schedule>> GetAll();
        public Task<Schedule> GetScheduleById(int id);
        public Task<List<Schedule>> GetSchedulesByTarotReaderId(int id);
    }

    public class ScheduleRepository : IScheduleRepository
    {
        public async Task<bool> AddSchedule(Schedule schedule)
        {
            return await ScheduleDAO.Instance.AddSchedule(schedule);
        }

        public async Task<bool> Delete(int id)
        {
            return await ScheduleDAO.Instance.Delete(id);
        }

        public async Task<List<Schedule>> GetAll()
        {
            return await ScheduleDAO.Instance.GetAll();
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
           return await ScheduleDAO.Instance.GetScheduleById(id);
        }

        public async Task<List<Schedule>> GetSchedulesByTarotReaderId(int id)
        {
            return await ScheduleDAO.Instance.GetSchedulesByTarotReaderId(id);
        }

        public async Task<bool> UpdateSchedule(Schedule schedule)
        {
            return await ScheduleDAO.Instance.UpdateSchedule(schedule);
        }
    }
}
