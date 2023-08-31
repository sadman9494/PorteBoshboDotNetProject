using AutoMapper;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        static AuthService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, User>();
                cfg.CreateMap<User, User>();
                cfg.CreateMap<Token, Token>();
                cfg.CreateMap<Token, Token>();
            });
        }
        public static Token Auth(User user)
        {
            var db_user = Mapper.Map<User>(user);
            var token = DataAccessFactory.AuthDataAccess().Authenticate(db_user);
            var tokenModel = Mapper.Map<Token>(token);
            return tokenModel;
            //convert user model to user
            //then send to auth repo
        }
        public static bool CheckValidityToken(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return rs;
        }
        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthDataAccess().Logout(token);
        }

        public static Token GetToken(string token)
        {
            return DataAccessFactory.AuthDataAccess().GetToken(token);
        }
    }
}
