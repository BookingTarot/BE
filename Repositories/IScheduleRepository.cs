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
        public bool AddSchedule(Schedule schedule);
    }

    public class ScheduleRepository : IScheduleRepository
    {
        public bool AddSchedule(Schedule schedule)
        {
            return ScheduleDAO.Instance.AddSchedule(schedule);
        }
    }
}
