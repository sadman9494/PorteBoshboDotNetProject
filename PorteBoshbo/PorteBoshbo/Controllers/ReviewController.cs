using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PorteBoshbo.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = ReviewService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = ReviewService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ReviewDTO Review)
        {
            if (ReviewService.Add(Review))
            {
                ViewBag.Message = "Review Added.";
                return View();
            }
            ViewBag.Message = "Review Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ReviewService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(ReviewDTO Review)
        {
            if (ReviewService.Update(Review))
            {
                ViewBag.Message = "Review Updated.";
                return View();
            }
            ViewBag.Message = "Review Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ReviewService.Delete(id))
            {
                ViewBag.Message = "Review Deleted.";
                return View();

            }
            ViewBag.Message = "Review Failed to Delete.";
            return View();
        }
    }
}
