using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TopicRepo : IRepo<Topic>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(Topic obj)
        {
            db.Topics.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Topic Get(int id)
        {
            return db.Topics.Find(id);
        }

        public List<Topic> GetAll()
        {
            return db.Topics.ToList();
        }

        public bool Remove(int id)
        {
            db.Topics.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(Topic obj)
        {
            db.Entry(Get(obj.TopicId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
