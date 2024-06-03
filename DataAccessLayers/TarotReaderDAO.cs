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
                        Customer = new Customer
                        {
                            CustomerId = sc.Customer.CustomerId,
                            UserId = sc.Customer.UserId,
                            User = new User
                            {
                                UserId = sc.Customer.User.UserId,
                                LastName = sc.Customer.User.LastName,
                                FirstName = sc.Customer.User.FirstName,
                               
                            }
                        }
                        


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
                        CustomerId = tr.CustomerId,
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

        public bool Update(TarotReader tarotReader)
        {
            try
            {
                context.Entry(tarotReader).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
