using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static PorteBoshboEntities db = new PorteBoshboEntities();
        public static IRepository<Token, string> TokenDataAccess()
        {
            return new TokenRepo(db);
        }
        public static IAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }

        public static IRepo<Course> CourseDataAccess()
        {
            return new CourseRepo();
        }
        public static IRepo<Department> DepartmentDataAccess()
        {
            return new DepartmentRepo();
        }

        public static IRepo<EducationLevel> EducationLevelDataAccess()
        {
            return new EducationLevelRepo();
        }
        public static IRepo<Payment> PaymentDataAccess()
        {
            return new PaymentRepo();
        }
        public static IPayment PaymentDataAccess2()
        {
            return new PaymentRepo();
        }
        public static IRepo<Review> ReviewDataAccess()
        {
            return new ReviewRepo();
        }
        public static IReview ReviewDataAccess2()
        {
            return new ReviewRepo();
        }
        public static IRepo<Session> SessionDataAccess()
        {
            return new SessionRepo();
        }
        public static ISession SessionDataAccess2()
        {
            return new SessionRepo();
        }
        public static IRepo<Topic> TopicDataAccess()
        {
            return new TopicRepo();
        }
        public static IRepo<User> UserDataAccess()
        {
            return new UserRepo();
        }

        public static IUserTopic UserTopicDataAccess()
        {
            return new UserTopicsRepo();
        }
    }
}
