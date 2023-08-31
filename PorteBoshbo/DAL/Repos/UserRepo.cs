using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : IRepo<User>, IAuth, IRepository<User, int>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Token Authenticate(User user)
        {
            var u = db.Users.FirstOrDefault(en => en.Username.Equals(user.Username) && en.Password.Equals(user.Password));
            Token t = null;
            if (u != null)
            {
                string token = Guid.NewGuid().ToString();
                t.UserId = u.UserId;
                t.AccessToken = token;
                t.CreatedAt = DateTime.Now;
                db.SaveChanges();

            }
            return t;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(User e)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public Token GetToken(string token)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated(string token)
        {
            var rs = db.Tokens.Any(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);
            return rs;
        }

        public bool Logout(string token)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            db.Users.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(User obj)
        {
            db.Entry(Get(obj.UserId)).CurrentValues.SetValues(obj);
            var v = db.SaveChanges();
            return db.SaveChanges() > 0;
        }

        void IRepository<User, int>.Add(User e)
        {
            throw new NotImplementedException();
        }
    }
}
