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
        public Task<List<TarotReader>> getAll();
        public Task<TarotReader> getTarotReaderById(int id);
        public Task<TarotReader> GetTarot(int id);
        public Task<bool> Add(TarotReader tarotReader);
        public Task<bool> Delete(int id);
        public Task<bool> Update(TarotReader tarotReader);
        public Task<bool> Save();
        Task<byte[]> GetImage(int id);


    }

    public class TarotReaderRepository : ITarotReaderRepository
    {
        public async Task<bool> Add(TarotReader tarotReader)
        {
            return await TarotReaderDAO.Instance.Add(tarotReader);
        }

        public async Task<bool> Delete(int id)
        {
            return await TarotReaderDAO.Instance.Delete(id);
        }

        public async Task<List<TarotReader>> getAll()
        {
            return await TarotReaderDAO.Instance.getAll();
        }

        public async Task<byte[]> GetImage(int id)
        {
            return await TarotReaderDAO.Instance.GetImage(id);
        }

        public async Task<TarotReader> GetTarot(int id)
        {
            return await TarotReaderDAO.Instance.GetTarot(id);
        }

        public async Task<TarotReader> getTarotReaderById(int id)
        {
            return await TarotReaderDAO.Instance.GetTarotReaderById(id);
        }

        public async Task<bool> Save()
        {
            return await TarotReaderDAO.Instance.SaveChanges();
        }

        public async Task<bool> Update(TarotReader tarotReader)
        {
            return await TarotReaderDAO.Instance.Update(tarotReader);
        }
    }
}
