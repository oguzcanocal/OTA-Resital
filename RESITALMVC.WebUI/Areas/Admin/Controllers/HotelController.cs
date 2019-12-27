using RESITALMVC.DAL.Context;
using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace RESITALMVC.WebUI.Areas.Admin.Controllers
{
    public class HotelController : Controller
    {
        HotelService db = new HotelService();
        ResitalContext rs = new ResitalContext();
        public ActionResult Index()
        {
            return View(rs.Hotels.ToList());
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

            return View(rs.Hotels.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Hotel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    rs.Entry(model).State = EntityState.Modified;
                    rs.SaveChanges();
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
            if (id == null)
            {
                TempData["ErrorMessage"] = "ID boş olamaz";
                return RedirectToAction("Index", "Hotel");
            }

            Hotel hotel = rs.Hotels.Find(id);
            
            return View(hotel);
        }


        public ActionResult DeleteConfirm(Guid id)
        {
            Hotel hotel = rs.Hotels.Find(id);
            rs.Hotels.Remove(hotel);
            rs.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}