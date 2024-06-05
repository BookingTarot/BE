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
        public bool AddFeedback(FeedBackRequest feedback);
        public List<Feedback> GetFeedbacks();
        public Feedback GetFeedbackById(int id);
        public bool UpdateFeedback(int id,FeedBackRequest feedback);
        public bool DeleteFeedback(int id);
        public List<Feedback> GetFeedbacksByTarotReaderId(int id);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repo;
        public FeedbackService(IFeedbackRepository repo)
        {
            _repo = repo;
        }
        public bool AddFeedback(FeedBackRequest request)
        {
            var feedback = new Feedback();
            feedback.CustomerId = request.CustomerId;
            feedback.TarotReaderId = request.TarotReaderId;
            feedback.Rating = request.Rating;
            feedback.Comments = request.Comments;
            feedback.Date = DateTime.Now;


            _repo.AddFeedback(feedback);
            return true;

        }

        public bool DeleteFeedback(int id)
        {
            return _repo.DeleteFeedback(id);
        }

        public Feedback GetFeedbackById(int id)
        {
           return _repo.GetFeedbackById(id);
        }

        public List<Feedback> GetFeedbacks()
        {
            return _repo.GetFeedbacks();
        }

        public List<Feedback> GetFeedbacksByTarotReaderId(int id)
        {
            return _repo.GetFeedbacksByTarotReaderId(id);
        }

        

        public bool UpdateFeedback(int id, FeedBackRequest request)
        {
            var feedback = _repo.GetFeedbackById(id);
            feedback.FeedbackId = id;
            feedback.CustomerId = request.CustomerId;
            feedback.TarotReaderId = request.TarotReaderId;
            feedback.Rating = request.Rating;
            feedback.Comments = request.Comments;
            return _repo.UpdateFeedback(feedback);

        }
    }
}
