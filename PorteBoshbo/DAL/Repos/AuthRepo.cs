using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class AuthRepo : IAuth
    {
        PorteBoshboEntities db;

        public AuthRepo(PorteBoshboEntities db)
        {
            this.db = db;
        }
        public Token Authenticate(User user)
        {
            Token t = null;
            var u = db.Users.FirstOrDefault(e => e.Email == user.Email && e.Password == user.Password);
            if (u != null)
            {
                var r = new Random();
                var g = Guid.NewGuid();
                var token = g.ToString();

                t = new Token()
                {
                    UserId = u.UserId,
                    AccessToken = token,
                    CreatedAt = DateTime.Now

                };
                db.Tokens.Add(t);
                db.SaveChanges();

            }

            return t;

        }
        public Token GetToken(string token) 
        {
            return db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);
        }
        public bool IsAuthenticated(string token)
        {
            var ac_token = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);
            if (ac_token != null) return true;
            return false;

        }

        public bool Logout(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
            if (t != null)
            {
                t.ExpiredAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
