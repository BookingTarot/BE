using BusinessObjects.Models;
using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITarotReaderRepository
    {
        public List<TarotReader> getAll();
        public TarotReader getTarotReaderById(int id);
        public bool Add(TarotReader tarotReader);
        public bool Delete(int id);
        public bool Update(TarotReader tarotReader);
    }

    public class TarotReaderRepository : ITarotReaderRepository
    {
        public bool Add(TarotReader tarotReader)
        {
            return TarotReaderDAO.Instance.Add(tarotReader);
        }

        public bool Delete(int id)
        {
            return TarotReaderDAO.Instance.Delete(id);
        }

        public List<TarotReader> getAll()
        {
            return TarotReaderDAO.Instance.getAll();
        }

        public TarotReader getTarotReaderById(int id)
        {
            return TarotReaderDAO.Instance.GetTarotReaderById(id);
        }

        public bool Update(TarotReader tarotReader)
        {
            return TarotReaderDAO.Instance.Update(tarotReader);
        }
    }
}
