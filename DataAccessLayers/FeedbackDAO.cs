using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class FeedbackDAO
    {
        private readonly TarotBookingContext context = null;
        private static FeedbackDAO instance;
        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedbackDAO();
                }
                return instance;
            }
        }
        public FeedbackDAO()
        {
            context = new TarotBookingContext();
        }
        public bool AddFeedback(Feedback feedback)
        {
            try
            {
               context.Feedbacks.Add(feedback);
               context.SaveChanges();
               return true;
                
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Feedback> GetFeedbacksByTarotReaderId(int id)
        {
            
                return context.Feedbacks.Where(f => f.TarotReaderId == id).ToList();
            
        }
        public List<Feedback> GetFeedbacks()
        {
            
                return context.Feedbacks.ToList();
            
        }
        public Feedback GetFeedbackById(int id)
        {
            
                return context.Feedbacks.Find(id);
            
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            try
            {
                var feedbackToUpdate = context.Feedbacks.Find(feedback.FeedbackId);
                if (feedbackToUpdate != null)
                {
                    feedbackToUpdate.CustomerId = feedback.CustomerId;
                    feedbackToUpdate.TarotReaderId = feedback.TarotReaderId;
                    feedbackToUpdate.Rating = feedback.Rating;
                    feedbackToUpdate.Comments = feedback.Comments;
                    feedbackToUpdate.Date = feedback.Date;
                    context.SaveChanges();
                    return context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteFeedback(int id)
        {
            try
            {
                var feedback = context.Feedbacks.Find(id);
                if (feedback != null)
                {
                    context.Feedbacks.Remove(feedback);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
