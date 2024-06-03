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
        public bool AddFeedback(Feedback feedback);
        public List<Feedback> GetFeedbacks();
        public Feedback GetFeedbackById(int id);
        public bool UpdateFeedback(Feedback feedback);
        public bool DeleteFeedback(int id);
        public List<Feedback> GetFeedbacksByTarotReaderId(int id);
    }

    public class FeedbackRepository : IFeedbackRepository
    {
        public bool AddFeedback(Feedback feedback)
        {
            return FeedbackDAO.Instance.AddFeedback(feedback);
        }

        public bool DeleteFeedback(int id)
        {
            return FeedbackDAO.Instance.DeleteFeedback(id);
        }

        public Feedback GetFeedbackById(int id)
        {
            return FeedbackDAO.Instance.GetFeedbackById(id);
        }

        public List<Feedback> GetFeedbacks()
        {
           return FeedbackDAO.Instance.GetFeedbacks();
        }

        public List<Feedback> GetFeedbacksByTarotReaderId(int id)
        {
            return FeedbackDAO.Instance.GetFeedbacksByTarotReaderId(id);
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            return FeedbackDAO.Instance.UpdateFeedback(feedback);
        }
    }
}
