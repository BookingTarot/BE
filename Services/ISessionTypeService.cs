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
    public interface ISessionTypeService
    {
        public bool DeleteSessionType(int id);
        public List<SessionType> GetSessionTypes();
        public SessionType GetSessionType(int id);
        public bool AddSessionType(SessionTypeRequest sessionType);
        public bool UpdateSessionType(SessionTypeRequest sessionType);
    }
    public class SessionTypeService : ISessionTypeService
    {
        private readonly ISessionTypeRepository sessionTypeRepository;
        public SessionTypeService(ISessionTypeRepository sessionTypeRepository)
        {
            this.sessionTypeRepository = sessionTypeRepository;
        }
        public bool AddSessionType(SessionTypeRequest sessionType)
        {
            var request = new SessionType
            {
                Name = sessionType.Name,
                Description = sessionType.Description,
                Duration = sessionType.Duration,
                Price = sessionType.Price,
                Status = sessionType.Status
            };
           
            return sessionTypeRepository.AddSessionType(request);
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

        public bool UpdateSessionType(SessionTypeRequest sessionType)
        {
            var request = sessionTypeRepository.GetSessionType(sessionType.SessionTypeId);
            if (request == null)
            {
                return false;
            }
            var update = new SessionType
            {
                SessionTypeId = sessionType.SessionTypeId,
                Name = sessionType.Name,
                Description = sessionType.Description,
                Duration = sessionType.Duration,
                Price = sessionType.Price,
                Status = sessionType.Status
            };
           return sessionTypeRepository.UpdateSessionType(update);
        }
    }
}
