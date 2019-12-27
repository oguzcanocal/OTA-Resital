using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace RESITALMVC.WebUI.Areas.Admin.Controllers
{
    public class HotelController : Controller
    {
        HotelService db = new HotelService();
        public ActionResult Index()
        {
            return View(db.GetAll());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hotel model)
        {
            try
            {
                
                
                if (ModelState.IsValid)
                {
                    model.ID = Guid.NewGuid();
                    db.Add(model);
                    return RedirectToAction("Index", "Hotel");
                }

                return View(model);
            }
            catch (Exception e)
            {

                ViewBag.Error = e.InnerException;
                return View(model);
            }

        }

        public ActionResult Edit(Guid id)
        {

            return View(db.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Hotel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var activationCodeHotel = db.GetById(model.ID);
                    db.Update(activationCodeHotel);
                    return RedirectToAction("Index", "Hotel");
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.InnerException;
                    return View(model);
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var deleted = db.GetById(id);
            return View(deleted);
        }

        [HttpPost]
        public ActionResult Delete(Hotel model)
        {
            try
            {
                db.Remove(model);
                return RedirectToAction("Index", "Hotel");
            }
            catch (Exception e)
            {

                ViewBag.Error = e.InnerException;
                return View();
            }
        }



    }
}