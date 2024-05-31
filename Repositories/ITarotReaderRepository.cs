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
    }

    public class TarotReaderRepository : ITarotReaderRepository
    {
        public List<TarotReader> getAll()
        {
            return TarotReaderDAO.Instance.getAll();
        }

        public TarotReader getTarotReaderById(int id)
        {
            return TarotReaderDAO.Instance.GetTarotReaderById(id);
        }
    }
}
