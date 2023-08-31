using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PorteBoshbo.Controllers
{
    public class SessionController : Controller
    {
        int a;
        [HttpGet]
        public ActionResult Index()
        {
            var data = SessionService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = SessionService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SessionDTO Session)
        {
            if (SessionService.Add(Session))
            {
                ViewBag.Message = "Session Added.";
                return View();
            }
            ViewBag.Message = "Session Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(SessionService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(SessionDTO Session)
        {
            if (SessionService.Update(Session))
            {
                ViewBag.Message = "Session Updated.";
                return View();
            }
            ViewBag.Message = "Session Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (SessionService.Delete(id))
            {
                ViewBag.Message = "Session Deleted.";
                return View();

            }
            ViewBag.Message = "Session Failed to Delete.";
            return View();
        }

        public ActionResult GetTeacherSessions(int id)
        {
            var s = SessionService.Get();
            var data = new List<SessionDTO>();
            foreach (var session in s)
            {
                if (session.Teacher.UserId == id)
                    data.Add(session);
            }
            return View(data);
        }

        [HttpGet]
        public ActionResult GetStudentSessions(int id)
        {
            var s = SessionService.Get();
            var data = new List<SessionDTO>();
            foreach (var session in s)
            {
                if (session.Student.UserId == id)
                    data.Add(session);
            }
            return View(data);
        }

        [HttpGet]
        public ActionResult SessionEnd(int id)
        {
            var data = SessionService.Get(id);
            data.SessionEnd = DateTime.Now;
            if (SessionService.Update(data))
            {
                var p = new PaymentDTO();
                p.Student.UserId = data.Student.UserId;
                p.Teacher.UserId = data.Teacher.UserId;
                p.Amount = (data.SessionEnd - data.SessionStart).TotalMinutes * 5;
                PaymentService.Add(p);
                ViewBag.Message = "Department Added.";
                return View();

            }
            ViewBag.Message = "Department Added.";
            return View();
        }

       
    }


}

