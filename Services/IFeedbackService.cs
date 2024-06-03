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
        public bool AddFeedback(Feedback feedback);
        public List<Feedback> GetFeedbacks();
        public Feedback GetFeedbackById(int id);
        public bool UpdateFeedback(Feedback feedback);
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
        public bool AddFeedback(Feedback feedback)
        {
            return _repo.AddFeedback(feedback);
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

        public bool UpdateFeedback(Feedback feedback)
        {
            return _repo.UpdateFeedback(feedback);
        }
    }
}
