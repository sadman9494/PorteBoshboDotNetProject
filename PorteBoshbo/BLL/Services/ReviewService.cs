using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class ReviewService
    {
        public static List<ReviewDTO> Get()
        {
            var reviews = new List<ReviewDTO>();
            var reviewdb = DataAccessFactory.ReviewDataAccess().GetAll();
            foreach (var review in reviewdb)
            {
                reviews.Add(new ReviewDTO()
                {
                    ReviewId= review.ReviewId,
                    ReviewText=review.ReviewText,
                    Rating= (double)review.Rating,
                    Teacher= UserService.GetShort((int)review.TeacherId),
                    Student= UserService.GetShort((int)review.StudentId),
                    Topic= TopicService.Get((int)review.TopicId),
                });
            }
            return reviews;
        }
        public static ReviewDTO Get(int id)
        {
            var reviewdb = DataAccessFactory.ReviewDataAccess().Get(id);
            var review = new ReviewDTO()
            {
                ReviewId = reviewdb.ReviewId,
                ReviewText = reviewdb.ReviewText,
                Rating = (double)reviewdb.Rating,
                Teacher = UserService.GetShort((int)reviewdb.TeacherId),
                Student = UserService.GetShort((int)reviewdb.StudentId),
                Topic = TopicService.Get((int)reviewdb.TopicId),
            };
            return review;
        }

        public static List<ReviewDTO> ReceivedReviews(int teacherId)
        {
            var reviews = new List<ReviewDTO>();
            var reviewdb = DataAccessFactory.ReviewDataAccess2().ReceivedReviews(teacherId);
            foreach (var review in reviewdb)
            {
                reviews.Add(new ReviewDTO()
                {
                    ReviewId = review.ReviewId,
                    ReviewText = review.ReviewText,
                    Rating = (double)review.Rating,
                    Teacher = UserService.GetShort((int)review.TeacherId),
                    Student = UserService.GetShort((int)review.StudentId),
                    Topic = TopicService.Get((int)review.TopicId),
                });
            }
            return reviews;
        }

        public static List<ReviewDTO> SubmittedReviews(int studentId)
        {
            var reviews = new List<ReviewDTO>();
            var reviewdb = DataAccessFactory.ReviewDataAccess2().ReceivedReviews(studentId);
            foreach (var review in reviewdb)
            {
                reviews.Add(new ReviewDTO()
                {
                    ReviewId = review.ReviewId,
                    ReviewText = review.ReviewText,
                    Rating = (double)review.Rating,
                    Teacher = UserService.GetShort((int)review.TeacherId),
                    Student = UserService.GetShort((int)review.StudentId),
                    Topic = TopicService.Get((int)review.TopicId),
                });
            }
            return reviews;
        }

        public static bool Add(ReviewDTO review)
        {
            var reviewdb = new Review()
            {
                ReviewId = review.ReviewId,
                ReviewText = review.ReviewText,
                Rating = (double)review.Rating,
                TeacherId = review.Teacher.UserId,
                StudentId = review.Student.UserId,
                TopicId = review.Topic.TopicId
            };
            return DataAccessFactory.ReviewDataAccess().Add(reviewdb);
        }
        public static bool Update(ReviewDTO review)
        {
            var reviewdb = DataAccessFactory.ReviewDataAccess().Get(review.ReviewId);
            reviewdb.ReviewText = review.ReviewText;
            reviewdb.Rating = (double)review.Rating;
            reviewdb.TeacherId = review.Teacher.UserId;
            reviewdb.StudentId = review.Student.UserId;
            reviewdb.TopicId = review.Topic.TopicId;

            return DataAccessFactory.ReviewDataAccess().Update(reviewdb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ReviewDataAccess().Remove(id);
        }

        public static List<ReviewDTO> top()
        {

            var reviews = new List<ReviewDTO>();
            var reviewdb = DataAccessFactory.ReviewDataAccess().GetAll();
            var sortedrating = from s in reviewdb
                               orderby s.Rating descending
                               select s;

            foreach (var review in sortedrating)
            {
                reviews.Add(new ReviewDTO()
                {
                    Rating = (double)review.Rating,
                    Teacher = UserService.GetShort((int)review.TeacherId),

                });

            }
            return reviews;
        }
    }
}
