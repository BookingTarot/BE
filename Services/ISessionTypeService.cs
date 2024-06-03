using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISessionTypeService
    {
        public bool DeleteSessionType(int id);
        public List<SessionType> GetSessionTypes();
        public SessionType GetSessionType(int id);
        public bool AddSessionType(SessionType sessionType);
        public bool UpdateSessionType(SessionType sessionType);
    }
    public class SessionTypeService : ISessionTypeService
    {
        private readonly ISessionTypeRepository sessionTypeRepository;
        public SessionTypeService(ISessionTypeRepository sessionTypeRepository)
        {
            this.sessionTypeRepository = sessionTypeRepository;
        }
        public bool AddSessionType(SessionType sessionType)
        {
            return sessionTypeRepository.AddSessionType(sessionType);
        }

        public bool DeleteSessionType(int id)
        {
            return sessionTypeRepository.DeleteSessionType(id);
        }

        public SessionType GetSessionType(int id)
        {
            return sessionTypeRepository.GetSessionType(id);
        }

        public List<SessionType> GetSessionTypes()
        {
           return sessionTypeRepository.GetSessionTypes();
        }

        public bool UpdateSessionType(SessionType sessionType)
        {
           return sessionTypeRepository.UpdateSessionType(sessionType);
        }
    }
}
