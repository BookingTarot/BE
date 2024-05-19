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
        public List<TarotReader> getAll();
    }
    public class TarotReaderService : ITarotReaderService
    {
        private readonly ITarotReaderRepository _repo;

        public TarotReaderService(ITarotReaderRepository repo)
        {
            _repo = repo;
        }
        public List<TarotReader> getAll()
        {
            return _repo.getAll();
        }
    }
}
