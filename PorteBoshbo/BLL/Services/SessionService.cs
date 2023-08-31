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
    public static class SessionService
    {
        public static List<SessionDTO> Get()
        {
            var sessions = new List<SessionDTO>();
            var sessiondb = DataAccessFactory.SessionDataAccess().GetAll();
            foreach (var session in sessiondb)
            {
                sessions.Add(new SessionDTO()
                {
                    SessionId= session.SessionId,
                    SessionStart= (DateTime)session.SessionStart,
                    SessionEnd= (DateTime)session.SessionEnd,
                    Link= session.Link,
                    Teacher = UserService.GetShort((int)session.TeacherId),
                    Student = UserService.GetShort((int)session.StudentId),
                });
            }
            return sessions;
        }
        public static SessionDTO Get(int id)
        {
            var sessiondb = DataAccessFactory.SessionDataAccess().Get(id);
            var session = new SessionDTO()
            {
                SessionId = sessiondb.SessionId,
                SessionStart = (DateTime)sessiondb.SessionStart,
                SessionEnd = (DateTime)sessiondb.SessionEnd,
                Link = sessiondb.Link,
                Teacher = UserService.GetShort((int)sessiondb.TeacherId),
                Student = UserService.GetShort((int)sessiondb.StudentId),
            };
            return session;
        }

        public static List<SessionDTO> GetUserSessions(int userId)
        {
            var sessions = new List<SessionDTO>();
            var sessiondb = DataAccessFactory.SessionDataAccess2().GetUserSessions(userId);
            foreach (var session in sessiondb)
            {
                sessions.Add(new SessionDTO()
                {
                    SessionId = session.SessionId,
                    SessionStart = (DateTime)session.SessionStart,
                    SessionEnd = (DateTime)session.SessionEnd,
                    Link = session.Link,
                    Teacher = UserService.GetShort((int)session.TeacherId),
                    Student = UserService.GetShort((int)session.StudentId),
                });
            }
            return sessions;
        }
        public static bool Add(SessionDTO session)
        {
            var sessiondb = new Session()
            {
                SessionId = session.SessionId,
                SessionStart = (DateTime)session.SessionStart,
                SessionEnd = (DateTime)session.SessionEnd,
                Link = session.Link,
                TeacherId = session.Teacher.UserId,
                StudentId = session.Student.UserId
        };
            return DataAccessFactory.SessionDataAccess().Add(sessiondb);
        }
        public static bool Update(SessionDTO session)
        {
            var sessiondb = DataAccessFactory.SessionDataAccess().Get(session.SessionId);
            sessiondb.SessionId = session.SessionId;
            sessiondb.SessionStart = (DateTime)session.SessionStart;
            sessiondb.SessionEnd = (DateTime)session.SessionEnd;
            sessiondb.Link = session.Link;
            sessiondb.TeacherId = session.Teacher.UserId;
            sessiondb.StudentId = session.Student.UserId;

            return DataAccessFactory.SessionDataAccess().Update(sessiondb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.SessionDataAccess().Remove(id);
        }
    }
}
