using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PorteBoshbo.Controllers
{
    public class TopicController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = TopicService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = TopicService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TopicDTO Topic)
        {
            if (TopicService.Add(Topic))
            {
                ViewBag.Message = "Topic Added.";
                return View();
            }
            ViewBag.Message = "Topic Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(TopicService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(TopicDTO Topic)
        {
            if (TopicService.Update(Topic))
            {
                ViewBag.Message = "Topic Updated.";
                return View();
            }
            ViewBag.Message = "Topic Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (TopicService.Delete(id))
            {
                ViewBag.Message = "Topic Deleted.";
                return View();

            }
            ViewBag.Message = "Topic Failed to Delete.";
            return View();
        }

        [Route("api/topics/teacher/{id}")]
        [HttpGet]
        public ActionResult GetUserTopics(int id)
        {
            var data = TopicService.GetUserTopics(id);
            return View(data);
        }
    }
}
