using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace PorteBoshbo.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = UserService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = UserService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserDTO User)
        {
            if (UserService.Add(User))
            {
                ViewBag.Message = "User Added.";
                return View();
            }
            ViewBag.Message = "User Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(UserService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(UserDTO User)
        {
            if (UserService.Update(User))
            {
                ViewBag.Message = "User Updated.";
                return View();
            }
            ViewBag.Message = "User Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (UserService.Delete(id))
            {
                ViewBag.Message = "User Deleted.";
                return View();

            }
            ViewBag.Message = "User Failed to Delete.";
            return View();
        }

        internal static object GetShort()
        {
            throw new NotImplementedException();
        }
    }
}
