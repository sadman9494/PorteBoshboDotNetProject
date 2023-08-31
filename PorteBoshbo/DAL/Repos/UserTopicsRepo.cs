using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserTopicsRepo : IRepo<UserTopic>, IUserTopic
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(UserTopic obj)
        {
            db.UserTopics.Add(obj);
            return db.SaveChanges() > 0;
        }

        public UserTopic Get(int id)
        {
            return db.UserTopics.Find(id);
        }

        public List<UserTopic> GetAll()
        {
            return db.UserTopics.ToList();
        }

        public List<Topic> GetUserTopic(int userId)
        {
            var topics = new List<Topic>();
            var usertopics = (from ut in db.UserTopics
                              where ut.TeacherId == userId
                              select ut).ToList();
            foreach(var usertopic in usertopics) 
            {
                topics.Add(db.Topics.Find(usertopic.TopicId));
            }
            return topics;
        }

        public bool Remove(int id)
        {
            db.UserTopics.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(UserTopic obj)
        {
            db.Entry(Get(obj.Id)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
