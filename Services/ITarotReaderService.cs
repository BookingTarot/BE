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
        public List<TarotReaderResponse> getAll();
    }
    public class TarotReaderService : ITarotReaderService
    {
        private readonly ITarotReaderRepository _repo;

        public TarotReaderService(ITarotReaderRepository repo)
        {
            _repo = repo;
        }
        public List<TarotReaderResponse> getAll()
        {   var tarotReaders = _repo.getAll();
            List<TarotReaderResponse> tarotReaderResponses = new List<TarotReaderResponse>();
            foreach(var tarotReader in tarotReaders)
            {
                TarotReaderResponse tarotReaderResponse = new TarotReaderResponse
                {
                    TarotReaderId = tarotReader.TarotReaderId,
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
    }
}
