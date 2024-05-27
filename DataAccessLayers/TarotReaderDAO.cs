using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class TarotReaderDAO
    {
        private readonly TarotBookingContext context = null;
        private static TarotReaderDAO _instance = null;
        public static TarotReaderDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TarotReaderDAO();
                }
                return _instance;
            }
        }
        public TarotReaderDAO()
        {
            context = new TarotBookingContext();
        }

        public List<TarotReader> getAll() {
            return context.TarotReaders
                
                .Select(tr => new TarotReader
                {
                    TarotReaderId = tr.TarotReaderId,
                    UserId = tr.UserId,
                    Introduction = tr.Introduction,
                    Description = tr.Description,
                    Image = tr.Image,
                    Status = tr.Status,
                    User = new User
                    {
                        UserId = tr.User.UserId,
                        LastName = tr.User.LastName,
                        FirstName = tr.User.FirstName,
                       
                    },
                    Schedules = tr.Schedules.Select(tr => new Schedule
                    {
                        ScheduleId = tr.ScheduleId,
                        Date = tr.Date,
                        StartTime = tr.StartTime, EndTime = tr.EndTime,


                    }).ToList()
                    ,
                    SessionTypes = tr.SessionTypes.Select(st => new SessionType
                    {
                        SessionTypeId = st.SessionTypeId,
                        Name = st.Name,
                        Description = st.Description,
                        Price = st.Price,
                        Status = st.Status,
                        Duration = st.Duration
                    }).ToList()


                })
                .ToList();
        }

    }
}
