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
        public Task<bool> DeleteSessionType(int id);
        public Task<List<SessionType>> GetSessionTypes();
        public Task<SessionType> GetSessionType(int id);
        public Task<bool> AddSessionType(SessionTypeRequest sessionType);
        public Task<bool> UpdateSessionType(SessionTypeRequest sessionType);
    }
    public class SessionTypeService : ISessionTypeService
    {
        private readonly ISessionTypeRepository sessionTypeRepository;
        private readonly ITarotReaderRepository tarotReaderRepository;
        public SessionTypeService(ISessionTypeRepository sessionTypeRepository, ITarotReaderRepository tarotReaderRepository)
        {
            this.sessionTypeRepository = sessionTypeRepository;
            this.tarotReaderRepository = tarotReaderRepository;
        }
        public async Task<bool> AddSessionType(SessionTypeRequest sessionType)
        {
            var request = new SessionType
            {
                Name = sessionType.Name,
                Description = sessionType.Description,
                Duration = sessionType.Duration,
                Price = sessionType.Price,
                Status = sessionType.Status
            };
           
            return await sessionTypeRepository.AddSessionType(request);
        }

        public async Task<bool> DeleteSessionType(int id)
        {
            return await sessionTypeRepository.DeleteSessionType(id);
        }

        public async Task<SessionType> GetSessionType(int id)
        {
            return await sessionTypeRepository.GetSessionType(id);
        }

        public async Task<List<SessionType>> GetSessionTypes()
        {
           return await sessionTypeRepository.GetSessionTypes();
        }

        public async Task<bool> UpdateSessionType(SessionTypeRequest sessionType)
        {
            var request = await sessionTypeRepository.GetSessionType(sessionType.SessionTypeId);
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
           return await sessionTypeRepository.UpdateSessionType(update);
        }
    }
}
