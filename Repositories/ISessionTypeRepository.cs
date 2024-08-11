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
        public Task<bool> DeleteSessionType(int id);
        public Task<List<SessionType>> GetSessionTypes();
        public Task<SessionType> GetSessionType(int id);
        public Task<bool> AddSessionType(SessionType sessionType);
        public Task<bool> UpdateSessionType(SessionType sessionType);

    }
    public class SessionTypeRepository : ISessionTypeRepository
    {
        public async Task<bool> AddSessionType(SessionType sessionType)
        {
           return await SessionTypeDAO.Instance.AddSessionType(sessionType);
        }

        public async Task<bool> DeleteSessionType(int id)
        {
            return await SessionTypeDAO.Instance.DeleteSessionType(id);
        }

        public async Task<SessionType> GetSessionType(int id)
        {
            return await SessionTypeDAO.Instance.GetSessionTypeById(id);
        }

        public async Task<List<SessionType>> GetSessionTypes()
        {
            return await SessionTypeDAO.Instance.GetSessionTypes();
        }

        public async Task<bool> UpdateSessionType(SessionType sessionType)
        {
            return await SessionTypeDAO.Instance.UpdateSessionType(sessionType);
        }
    }
}
