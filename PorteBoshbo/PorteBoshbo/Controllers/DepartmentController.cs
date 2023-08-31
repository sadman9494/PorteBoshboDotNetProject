using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PorteBoshbo.Controllers
{
    public class DepartmentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = DepartmentService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = DepartmentService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentDTO Department)
        {
            if (DepartmentService.Add(Department))
            {
                ViewBag.Message = "Department Added.";
                return View();
            }
            ViewBag.Message = "Department Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(DepartmentService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(DepartmentDTO Department)
        {
            if (DepartmentService.Update(Department))
            {
                ViewBag.Message = "Department Updated.";
                return View();
            }
            ViewBag.Message = "Department Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (DepartmentService.Delete(id))
            {
                ViewBag.Message = "Department Deleted.";
                return View();

            }
            ViewBag.Message = "Department Failed to Delete.";
            return View();
        }
    }
}
