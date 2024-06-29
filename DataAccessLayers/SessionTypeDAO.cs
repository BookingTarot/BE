using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class SessionTypeDAO
    {
        private readonly TarotBookingContext context = null;
        private static SessionTypeDAO instance;
        public static SessionTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionTypeDAO();
                }
                return instance;
            }
        }
        public SessionTypeDAO()
        {
            context = new TarotBookingContext();
        }
        public bool AddSessionType(SessionType sessionType)
        {
            try
            {
                context.SessionTypes.Add(sessionType);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<SessionType> GetSessionTypes()
        {
            return context.SessionTypes.ToList();
        }
        public SessionType GetSessionTypeById(int id)
        {
            return context.SessionTypes.Find(id);
        }

        public bool UpdateSessionType(SessionType sessionType)
        {
            try
            {
                var sessionTypeToUpdate = context.SessionTypes.Find(sessionType.SessionTypeId);
                sessionTypeToUpdate.Name = sessionType.Name;
                sessionTypeToUpdate.Description = sessionType.Description;
                sessionTypeToUpdate.Price = sessionType.Price;
                sessionTypeToUpdate.Status = sessionType.Status;
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteSessionType(int id)
        {
            try
            {
                var sessionTypeToDelete = context.SessionTypes.Find(id);
                context.SessionTypes.Remove(sessionTypeToDelete);
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
