using RESITALMVC.DAL.Context;
using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Option;
using RESITALMVC.WebUI.Areas.Admin.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESITALMVC.WebUI.Areas.Admin.Controllers
{
    public class RateController : Controller
    {
        RateService rs = new RateService();
        ResitalContext context = new ResitalContext();

        // GET: Admin/Rate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listing(Guid RoomID)
        {
            RateTypesModel model = new RateTypesModel();
            model.RateTypes = rs.GetAllRate().Where(x => x.RoomID == RoomID);
            return PartialView("_RateListing", model);

        }

        public ActionResult Create(Guid RoomID)
        {
            RateTypesCreateModel model = new RateTypesCreateModel();
            model.RoomID = RoomID;

            return PartialView("_RateCreatePW", model);
        }

        [HttpPost]
        public JsonResult Create(Rate model)
        {
            JsonResult json = new JsonResult();

            Rate rate = new Rate();
            rate.ID = Guid.NewGuid();
            rate.RoomID = model.RoomID;
            rate.RateName = model.RateName;

            var result = rs.SaveRate(rate);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Fiyat Planı Eklenemedi" };
            }

            return json;

        }

        public ActionResult Edit(Guid id)
        {
            Rate rate = context.Rates.Find(id);

            return View(rate);
        }

        [HttpPost]
        public ActionResult Edit(Rate rate)
        {
            context.Entry(rate).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Rate", new { rate.RoomID });
        }

        public ActionResult Delete(Guid id)
        {
            Rate rate = context.Rates.Find(id);
            return View(rate);
        }

        public ActionResult DeleteConfirm(Guid id)
        {
            Rate rate = context.Rates.Find(id);
            context.Rates.Remove(rate);
            context.SaveChanges();
            return RedirectToAction("Index", "Rate", new { rate.RoomID });
        }


    }
}