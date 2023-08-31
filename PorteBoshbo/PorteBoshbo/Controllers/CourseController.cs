using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLL.DTOs;
using BLL.Services;

namespace PorteBoshbo.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = CourseService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = CourseService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseDTO course)
        {
            if (CourseService.Add(course))
            {
                ViewBag.Message = "Course Added.";
                return View();
            }
            ViewBag.Message = "Course Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(CourseService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(CourseDTO course)
        {
            if (CourseService.Update(course))
            {
                ViewBag.Message = "Course Updated.";
                return View();
            }
            ViewBag.Message = "Course Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (CourseService.Delete(id))
            {
                ViewBag.Message = "Course Deleted.";
                return View();

            }
            ViewBag.Message = "Course Failed to Delete.";
            return View();
        }
    }
}
