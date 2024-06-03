using BusinessObjects.Models;
using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISessionTypeRepository
    {
        public bool DeleteSessionType(int id);
        public List<SessionType> GetSessionTypes();
        public SessionType GetSessionType(int id);
        public bool AddSessionType(SessionType sessionType);
        public bool UpdateSessionType(SessionType sessionType);

    }
    public class SessionTypeRepository : ISessionTypeRepository
    {
        public bool AddSessionType(SessionType sessionType)
        {
           return SessionTypeDAO.Instance.AddSessionType(sessionType);
        }

        public bool DeleteSessionType(int id)
        {
            return SessionTypeDAO.Instance.DeleteSessionType(id);
        }

        public SessionType GetSessionType(int id)
        {
            return SessionTypeDAO.Instance.GetSessionTypeById(id);
        }

        public List<SessionType> GetSessionTypes()
        {
            return SessionTypeDAO.Instance.GetSessionTypes();
        }

        public bool UpdateSessionType(SessionType sessionType)
        {
            return SessionTypeDAO.Instance.UpdateSessionType(sessionType);
        }
    }
}
