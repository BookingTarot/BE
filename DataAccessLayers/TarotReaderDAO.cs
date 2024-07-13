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
                    Kind = tr.Kind,
                    Experience = tr.Experience,
                    Image = tr.Image,
                    Status = tr.Status,
                    User = new User
                    {
                        UserId = tr.User.UserId,
                        LastName = tr.User.LastName,
                        FirstName = tr.User.FirstName,
                       
                    },
                    Schedules = tr.Schedules.Select(sc => new Schedule
                    {
                        ScheduleId = sc.ScheduleId,
                        Date = sc.Date,
                        StartTime = sc.StartTime, EndTime = sc.EndTime,
                        
                        


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
        public TarotReader GetTarot(int id)
        {
            return context.TarotReaders.Include(tr => tr.SessionTypes).Where(tr => tr.TarotReaderId == id).FirstOrDefault();
        }
        public TarotReader GetTarotReaderById(int id)
        {
            return context.TarotReaders
                .Where(tr => tr.TarotReaderId == id)
                .Select(tr => new TarotReader
                {
                    TarotReaderId = tr.TarotReaderId,
                    UserId = tr.UserId,
                    Introduction = tr.Introduction,
                    Description = tr.Description,
                    Kind = tr.Kind,
                    Experience = tr.Experience,
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
                        StartTime = tr.StartTime,
                        EndTime = tr.EndTime,
                       
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
                .FirstOrDefault();
        }

        public bool Add(TarotReader tarotReader)
        {
            try
            {
                context.TarotReaders.Add(tarotReader);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var tarotReader = context.TarotReaders.Find(id);
                context.TarotReaders.Remove(tarotReader);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public bool Update(TarotReader tarotReader)
        {
            
                
                var tarot = context.TarotReaders.Find(tarotReader.TarotReaderId);
                if (tarot == null)
                {
                    return false;
                }
                tarot.Introduction = tarotReader.Introduction;
                tarot.Description = tarotReader.Description;
                tarot.Experience = tarotReader.Experience;
                tarot.Kind = tarotReader.Kind;
                tarot.Image = tarotReader.Image;
                tarot.Status = tarotReader.Status;
                //context.TarotReaders.Update(tarot);
                return context.SaveChanges() > 0;
            
        }
    }
}
