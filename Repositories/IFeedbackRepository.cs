using BusinessObjects.Models;
using DataAccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFeedbackRepository
    {
        public Task<bool> AddFeedback(Feedback feedback);
        public Task<List<Feedback>> GetFeedbacks();
        public Task<Feedback> GetFeedbackById(int id);
        public Task<bool> UpdateFeedback(Feedback feedback);
        public Task<bool> DeleteFeedback(int id);
        public Task<List<Feedback>> GetFeedbacksByTarotReaderId(int id);
    }

    public class FeedbackRepository : IFeedbackRepository
    {
        public async Task<bool> AddFeedback(Feedback feedback)
        {
            return await FeedbackDAO.Instance.AddFeedback(feedback);
        }

        public async Task<bool> DeleteFeedback(int id)
        {
            return await FeedbackDAO.Instance.DeleteFeedback(id);
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await FeedbackDAO.Instance.GetFeedbackById(id);
        }

        public async Task<List<Feedback>> GetFeedbacks()
        {
           return await FeedbackDAO.Instance.GetFeedbacks();
        }

        public async Task<List<Feedback>> GetFeedbacksByTarotReaderId(int id)
        {
            return await FeedbackDAO.Instance.GetFeedbacksByTarotReaderId(id);
        }

        public async Task<bool> UpdateFeedback(Feedback feedback)
        {
            return await FeedbackDAO.Instance.UpdateFeedback(feedback);
        }
    }
}
