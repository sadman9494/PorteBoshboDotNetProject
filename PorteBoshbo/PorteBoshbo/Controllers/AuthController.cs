using BLL.Services;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;

namespace PorteBoshbo.Controllers
{
    //[EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpOptions]
        public HttpResponseMessage UpdateOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Auth(User user)
        {
            var data = AuthService.Auth(user);
            var tmpuser = UserService.Get();
            foreach(var u in tmpuser)
            {
                if(u.Email == user.Email)
                {
                    user.UserId = u.UserId;
                }
            }
            if (data != null)
            {
                var s = "{ \"UserId\": \""+user.UserId+"\" , \"Token\": \""+data.AccessToken+"\"}";
                return Request.CreateResponse(HttpStatusCode.OK, s);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            //var token = Request.Headers.Authorization.ToString();
            if (Request.Headers.Authorization!= null && Request.Headers.Authorization.ToString() != null)
            {
                var rs = AuthService.Logout(Request.Headers.Authorization.ToString());
                if (rs)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sucessfully logged out");
                }

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token to logout");
        }

    }
}
