using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PorteBoshbo.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = PaymentService.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = PaymentService.Get(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PaymentDTO Payment)
        {
            if (PaymentService.Add(Payment))
            {
                ViewBag.Message = "Payment Added.";
                return View();
            }
            ViewBag.Message = "Payment Failed to Add.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(PaymentService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(PaymentDTO Payment)
        {
            if (PaymentService.Update(Payment))
            {
                ViewBag.Message = "Payment Updated.";
                return View();
            }
            ViewBag.Message = "Payment Failed to Update.";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (PaymentService.Delete(id))
            {
                ViewBag.Message = "Payment Deleted.";
                return View();

            }
            ViewBag.Message = "Payment Failed to Delete.";
            return View();
        }
    }
}
