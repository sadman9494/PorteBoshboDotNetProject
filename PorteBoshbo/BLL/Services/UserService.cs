using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public static class UserService
    {
        public static List<UserDTO> Get()
        {
            var users = new List<UserDTO>();
            var userdb = DataAccessFactory.UserDataAccess().GetAll();
            foreach (var user in userdb)
            {
                users.Add(new UserDTO()
                {
                    UserId= user.UserId,
                    Name= user.Name,
                    Username= user.Username,
                    Email= user.Email,
                    Password= user.Password,
                    Role= user.Role,
                    Balance= (double)user.Balance,
                    Department= DepartmentService.Get((int)user.DepartmentId),
                    EducationLevel= EducationLevelService.Get((int)user.EducationLevelId),
                    ReceivedPayments= PaymentService.ReceivedPayments(user.UserId),
                    PaidPayments= PaymentService.PaidPayments(user.UserId),
                    ReceivedReviews = ReviewService.ReceivedReviews(user.UserId),
                    SubmittedReviews = ReviewService.SubmittedReviews(user.UserId),
                    Sessions= SessionService.GetUserSessions(user.UserId)
                });
            }
            return users;
        }
        public static UserDTO Get(int id)
        {
            var userdb = DataAccessFactory.UserDataAccess().Get(id);
            var user = new UserDTO()
            {
                UserId = userdb.UserId,
                Name = userdb.Name,
                Username = userdb.Username,
                Email = userdb.Email,
                Password = userdb.Password,
                Role = userdb.Role,
                Balance = (double)userdb.Balance,
                Department = DepartmentService.Get((int)userdb.DepartmentId),
                EducationLevel = EducationLevelService.Get((int)userdb.EducationLevelId),
                ReceivedPayments = PaymentService.ReceivedPayments(userdb.UserId),
                PaidPayments = PaymentService.PaidPayments(userdb.UserId),
                ReceivedReviews = ReviewService.ReceivedReviews(userdb.UserId),
                SubmittedReviews = ReviewService.SubmittedReviews(userdb.UserId)
            };
            return user;
        }
        public static UserDTO GetShort(int id)
        {
            var userdb = DataAccessFactory.UserDataAccess().Get(id);
            var user = new UserDTO()
            {
                UserId = userdb.UserId,
                Name = userdb.Name,
                Username = userdb.Username,
                Email = userdb.Email,
                Password = userdb.Password,
                Role = userdb.Role,
                Balance = (double)userdb.Balance,
                Department = DepartmentService.Get((int)userdb.DepartmentId),
                EducationLevel = EducationLevelService.Get((int)userdb.DepartmentId)
            };
            return user;
        }

        public static bool Add(UserDTO user)
        {
            var userdb = new User()
            {
                UserId = user.UserId,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Balance = (double)user.Balance,
                DepartmentId = user.Department.DepartmentId,
                EducationLevelId = user.EducationLevel.EducationLevelId
            };
            return DataAccessFactory.UserDataAccess().Add(userdb);
        }
        public static bool Update(UserDTO user)
        {
            var userdb = DataAccessFactory.UserDataAccess().Get(user.UserId);
            userdb.UserId = user.UserId;
            userdb.Name = user.Name;
            userdb.Username = user.Username;
            userdb.Email = user.Email;
            userdb.Password = user.Password;
            userdb.Role = user.Role;
            userdb.Balance = (double)user.Balance;
            userdb.DepartmentId = user.Department.DepartmentId;
            userdb.EducationLevelId = user.EducationLevel.EducationLevelId;

            return DataAccessFactory.UserDataAccess().Update(userdb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Remove(id);
        }

        public static int total()
        {
            int total = 0;
            var users = new List<UserDTO>();
            var userdb = DataAccessFactory.UserDataAccess().GetAll();
            foreach (var user in userdb)
            {
                if (user.Role == "User")
                {
                    total++;
                }
            }
            return total;
        }
    }
}
