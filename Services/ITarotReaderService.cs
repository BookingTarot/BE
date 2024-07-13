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
        public List<TarotReaderResponse> getAll(GetListTarotReaderRequest request);
        public TarotReaderResponse getTarotReaderById(int id);
        public bool Add(TarotReaderRequest tarotReader);
        public bool Delete(int id);
        public bool Update(TarotReaderRequest tarotReader);
        public bool AddSessionTypeToTarotReader(SessionTypeToTarotReaderRequest sessionTypeToTarotReader);
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

        public bool Add(TarotReaderRequest tarotReader)
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
            return _repo.Add(request);
        }

        public bool AddSessionTypeToTarotReader(SessionTypeToTarotReaderRequest sessionTypeToTarotReader)
        {
            var tarotReader = _repo.GetTarot(sessionTypeToTarotReader.TarotReaderId);
            if (tarotReader != null)
            {


                var sessionType = _sessionTypeRepository.GetSessionType(sessionTypeToTarotReader.SessionTypeId);
                if (sessionType != null)
                {
                    tarotReader.SessionTypes.Add(sessionType);
                    return _repo.Save();
                }
                
            }
            return false;

        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<TarotReaderResponse> getAll(GetListTarotReaderRequest request)
        {   
            
            var tarotReaders = (_repo.getAll()).AsQueryable();
            if (!string.IsNullOrEmpty(request.Kind))
            {
                tarotReaders = tarotReaders.Where(x => x.Kind.Contains(request.Kind));
            }
            if(!string.IsNullOrEmpty(request.Experience))
            {
                tarotReaders = tarotReaders.Where(x => x.Experience.Contains(request.Experience));
            }
            var tarotReaderResponses = new List<TarotReaderResponse>();
            foreach(var tarotReader in tarotReaders)
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
                    Image = tarotReader.Image,
                    Status = tarotReader.Status,
                    Schedules = tarotReader.Schedules.ToList(),
                    
                    SessionTypes = tarotReader.SessionTypes.ToList()
                };
                tarotReaderResponses.Add(tarotReaderResponse);
            }
            return tarotReaderResponses;
        }

        public TarotReaderResponse getTarotReaderById(int id)
        {
            var tarotReader = _repo.getTarotReaderById(id);
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

        public bool Update(TarotReaderRequest tarotReader)
        {
            var request = _repo.getTarotReaderById(tarotReader.TarotReaderId);
            request.Introduction = tarotReader.Introduction;
            request.Description = tarotReader.Description;
            request.Experience = tarotReader.Experience;
            request.Kind = tarotReader.Kind;
            request.Image = tarotReader.Image;
            request.Status = tarotReader.Status;
            return _repo.Update(request);
        }
    }
}
