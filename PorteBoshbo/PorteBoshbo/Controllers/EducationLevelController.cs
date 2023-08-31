using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PorteBoshbo.Controllers
{
    public class EducationLevelController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = EducationLevelService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = EducationLevelService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EducationLevelDTO EducationLevel)
        {
            if (EducationLevelService.Add(EducationLevel))
            {
                ViewBag.Message = "EducationLevel Added.";
                return View();
            }
            ViewBag.Message = "EducationLevel Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(EducationLevelService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(EducationLevelDTO EducationLevel)
        {
            if (EducationLevelService.Update(EducationLevel))
            {
                ViewBag.Message = "EducationLevel Updated.";
                return View();
            }
            ViewBag.Message = "EducationLevel Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (EducationLevelService.Delete(id))
            {
                ViewBag.Message = "EducationLevel Deleted.";
                return View();

            }
            ViewBag.Message = "EducationLevel Failed to Delete.";
            return View();
        }
    }
}
