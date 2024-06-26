﻿using BusinessObjects.Models;
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
        public bool UpdateSchedule(Schedule schedule);
        public bool Delete(int id);
        public List<Schedule> GetAll();
        public Schedule GetScheduleById(int id);
        public List<Schedule> GetSchedulesByTarotReaderId(int id);
    }

    public class ScheduleRepository : IScheduleRepository
    {
        public bool AddSchedule(Schedule schedule)
        {
            return ScheduleDAO.Instance.AddSchedule(schedule);
        }

        public bool Delete(int id)
        {
            return ScheduleDAO.Instance.Delete(id);
        }

        public List<Schedule> GetAll()
        {
            return ScheduleDAO.Instance.GetAll();
        }

        public Schedule GetScheduleById(int id)
        {
           return ScheduleDAO.Instance.GetScheduleById(id);
        }

        public List<Schedule> GetSchedulesByTarotReaderId(int id)
        {
            return ScheduleDAO.Instance.GetSchedulesByTarotReaderId(id);
        }

        public bool UpdateSchedule(Schedule schedule)
        {
            return ScheduleDAO.Instance.UpdateSchedule(schedule);
        }
    }
}
