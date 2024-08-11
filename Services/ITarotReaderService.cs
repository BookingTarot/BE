using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITarotReaderService
    {
        public Task<List<TarotReaderResponse>> getAll(GetListTarotReaderRequest request);
        public Task<TarotReaderResponse> getTarotReaderById(int id);
        public Task<bool> Add(TarotReaderRequest tarotReader);
        public Task<bool> Delete(int id);
        public Task<bool> Update(TarotReaderRequest tarotReader);
        public Task<bool> AddSessionTypeToTarotReader(SessionTypeToTarotReaderRequest sessionTypeToTarotReader);
    }
    public class TarotReaderService : ITarotReaderService
    {
        private readonly ITarotReaderRepository _repo;
        private readonly ISessionTypeRepository _sessionTypeRepository;
        
    

        public TarotReaderService(ITarotReaderRepository repo, ISessionTypeRepository sessionTypeRepository)
        {
            _repo = repo;
            _sessionTypeRepository = sessionTypeRepository;
            
        }

        public async Task<bool> Add(TarotReaderRequest tarotReader)
        {
            var request = new TarotReader
            {
                UserId = tarotReader.UserId,
                Introduction = tarotReader.Introduction,
                Description = tarotReader.Description,
                Experience = tarotReader.Experience,
                Kind = tarotReader.Kind,
                Image = tarotReader.Image,
                Status = tarotReader.Status
            };
            return await _repo.Add(request);
        }

        public async Task<bool> AddSessionTypeToTarotReader(SessionTypeToTarotReaderRequest sessionTypeToTarotReader)
        {
            var tarotReader = await _repo.GetTarot(sessionTypeToTarotReader.TarotReaderId);
            if (tarotReader != null)
            {


                var sessionType = await _sessionTypeRepository.GetSessionType(sessionTypeToTarotReader.SessionTypeId);
                if (sessionType != null)
                {
                    tarotReader.SessionTypes.Add(sessionType);
                    return await _repo.Update(tarotReader);
                }
                
            }
            return false;

        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<List<TarotReaderResponse>> getAll(GetListTarotReaderRequest request)
        {   
            
            var tarotReaders = (await _repo.getAll()).AsQueryable();
            if (!string.IsNullOrEmpty(request.Kind))
            {
                tarotReaders = tarotReaders.Where(x => x.Kind.Contains(request.Kind));
            }
            if(!string.IsNullOrEmpty(request.Experience))
            {
                tarotReaders = tarotReaders.Where(x => x.Experience.Contains(request.Experience));
            }
            var tarotReaderResponses = new List<TarotReaderResponse>();
            var tarotReaderIds = tarotReaders.Select(x => x.TarotReaderId).ToList();
            var imageDict = new Dictionary<int, byte[]>();

            foreach (var id in tarotReaderIds)
            {
                var image = await _repo.GetImage(id);
                if (image != null)
                {
                    imageDict[id] = image;
                }
            }
            foreach (var tarotReader in tarotReaders)
            {
                TarotReaderResponse tarotReaderResponse = new TarotReaderResponse
                {
                    TarotReaderId = tarotReader.TarotReaderId,
                    UserId = tarotReader.UserId,
                    FullName = tarotReader.User.FirstName + " " + tarotReader.User.LastName,
                    Introduction = tarotReader.Introduction,
                    Description = tarotReader.Description,
                    Experience = tarotReader.Experience,
                    Kind = tarotReader.Kind,
                    Image = imageDict.ContainsKey(tarotReader.TarotReaderId) ? imageDict[tarotReader.TarotReaderId] : null,
                    Status = tarotReader.Status,
                    Schedules = tarotReader.Schedules.ToList(),
                    
                    SessionTypes = tarotReader.SessionTypes.ToList()
                };
                tarotReaderResponses.Add(tarotReaderResponse);
            }
            return tarotReaderResponses;
        }

        public async Task<TarotReaderResponse> getTarotReaderById(int id)
        {
            var tarotReader = await _repo.getTarotReaderById(id);
            TarotReaderResponse tarotReaderResponse = new TarotReaderResponse
            {
                TarotReaderId = tarotReader.TarotReaderId,
                UserId = tarotReader.UserId,
                FullName = tarotReader.User.FirstName + " " + tarotReader.User.LastName,
                Introduction = tarotReader.Introduction,
                Description = tarotReader.Description,
                Experience = tarotReader.Experience,
                Kind = tarotReader.Kind,
                Image = tarotReader.Image,
                Status = tarotReader.Status,
                Schedules = tarotReader.Schedules.ToList(),

                SessionTypes = tarotReader.SessionTypes.ToList()
            };
            return tarotReaderResponse;
        }

        public async Task<bool> Update(TarotReaderRequest tarotReader)
        {
            var request = await _repo.getTarotReaderById(tarotReader.TarotReaderId);
            request.Introduction = tarotReader.Introduction;
            request.Description = tarotReader.Description;
            request.Experience = tarotReader.Experience;
            request.Kind = tarotReader.Kind;
            request.Image = tarotReader.Image;
            request.Status = tarotReader.Status;
            return await _repo.Update(request);
        }
    }
}
