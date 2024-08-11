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
    public interface  IFeedbackService
    {
        public Task<bool> AddFeedback(FeedBackRequest feedback);
        public Task<List<Feedback>> GetFeedbacks();
        public Task<Feedback> GetFeedbackById(int id);
        public Task<bool> UpdateFeedback(int id,FeedBackRequest feedback);
        public Task<bool> DeleteFeedback(int id);
        public Task<List<Feedback>> GetFeedbacksByTarotReaderId(int id);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repo;
        public FeedbackService(IFeedbackRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddFeedback(FeedBackRequest request)
        {
            var feedback = new Feedback();
            feedback.CustomerId = request.CustomerId;
            feedback.TarotReaderId = request.TarotReaderId;
            feedback.Rating = request.Rating;
            feedback.Comments = request.Comments;
            feedback.Date = DateTime.Now;


            await _repo.AddFeedback(feedback);
            return true;

        }

        public async Task<bool> DeleteFeedback(int id)
        {
            return await _repo.DeleteFeedback(id);
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
           return await _repo.GetFeedbackById(id);
        }

        public async Task<List<Feedback>> GetFeedbacks()
        {
            return await _repo.GetFeedbacks();
        }

        public async Task<List<Feedback>> GetFeedbacksByTarotReaderId(int id)
        {
            return await _repo.GetFeedbacksByTarotReaderId(id);
        }

        

        public async Task<bool> UpdateFeedback(int id, FeedBackRequest request)
        {
            var feedback = await _repo.GetFeedbackById(id);
            feedback.FeedbackId = id;
            feedback.CustomerId = request.CustomerId;
            feedback.TarotReaderId = request.TarotReaderId;
            feedback.Rating = request.Rating;
            feedback.Comments = request.Comments;
            return await _repo.UpdateFeedback(feedback);

        }
    }
}
