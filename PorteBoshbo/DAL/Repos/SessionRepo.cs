using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SessionRepo : IRepo<Session>, ISession
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(Session obj)
        {
            db.Sessions.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Session Get(int id)
        {
            return db.Sessions.Find(id);
        }

        public List<Session> GetAll()
        {
            return db.Sessions.ToList();
        }

        public List<Session> GetUserSessions(int userId)
        {
            var sessions = (from r in db.Sessions
                           where r.TeacherId == userId || r.StudentId== userId
                           select r).ToList();
            return sessions;
        }

        public bool Remove(int id)
        {
            db.Sessions.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(Session obj)
        {
            db.Entry(Get(obj.SessionId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
