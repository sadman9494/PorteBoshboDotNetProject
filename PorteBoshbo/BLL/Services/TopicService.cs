using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class TopicService
    {
        public static List<TopicDTO> Get()
        {
            var topics = new List<TopicDTO>();
            var topicdb = DataAccessFactory.TopicDataAccess().GetAll();
            foreach (var topic in topicdb)
            {
                topics.Add(new TopicDTO()
                {
                    TopicId = topic.TopicId,
                    TopicName = topic.TopicName,
                    EducationLevel = EducationLevelService.Get(topic.TopicId),
                    Department = DepartmentService.Get((int)topic.DepartmentId),
                    Course = CourseService.Get((int)topic.CourseId)
                });
            }
            return topics;
        }
        public static TopicDTO Get(int id)
        {
            var topicdb = DataAccessFactory.TopicDataAccess().Get(id);
            var topic = new TopicDTO()
            {
                TopicId = topicdb.TopicId,
                TopicName = topicdb.TopicName,
                EducationLevel = EducationLevelService.Get(topicdb.TopicId),
                Department = DepartmentService.Get((int)topicdb.DepartmentId),
                Course = CourseService.Get((int)topicdb.CourseId)
            };
            return topic;
        }
        public static List<TopicDTO> GetUserTopics(int userId)
        {
            var usertopics = DataAccessFactory.UserTopicDataAccess().GetUserTopic(userId);
            var topics = new List<TopicDTO>();
            
            foreach (var t in usertopics)
            {
                var topic = DataAccessFactory.TopicDataAccess().Get(t.TopicId);
                topics.Add(new TopicDTO()
                {
                    TopicId = topic.TopicId,
                    TopicName = topic.TopicName,
                    EducationLevel = EducationLevelService.Get(topic.TopicId),
                    Department = DepartmentService.Get((int)topic.DepartmentId),
                    Course = CourseService.Get((int)topic.CourseId)
                });
            }
            return topics;
        }
        public static bool Add(TopicDTO topic)
        {
            var topicdb = new Topic()
            {
                TopicId = topic.TopicId,
                TopicName = topic.TopicName,
                EducationLevelId = topic.EducationLevel.EducationLevelId,
                DepartmentId = topic.Department.DepartmentId,
                CourseId = topic.Course.CourseId
            };
            return DataAccessFactory.TopicDataAccess().Add(topicdb);
        }
        public static bool Update(TopicDTO topic)
        {
            var topicdb = DataAccessFactory.TopicDataAccess().Get(topic.TopicId);
            topicdb.TopicId = topic.TopicId;
            topicdb.TopicName = topic.TopicName;
         //   topicdb.EducationLevelId = topic.EducationLevel.EducationLevelId;
           // topicdb.DepartmentId = topic.Department.DepartmentId;
          //  topicdb.CourseId = topic.Course.CourseId;

            return DataAccessFactory.TopicDataAccess().Update(topicdb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.TopicDataAccess().Remove(id);
        }

        public static int total()
        {

            int total = 0;
            var topics = new List<TopicDTO>();
            var topicdb = DataAccessFactory.TopicDataAccess().GetAll();
            foreach (var topic in topicdb)
            {
                total++;
            }
            return total;
        }
    }
}
