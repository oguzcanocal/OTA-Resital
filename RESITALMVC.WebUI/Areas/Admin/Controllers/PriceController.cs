using RESITALMVC.DAL.Context;
using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESITALMVC.WebUI.Areas.Admin.Controllers
{
    public class PriceController : Controller
    {
        PriceService ps = new PriceService();
        ResitalContext rs = new ResitalContext();
        // GET: Admin/Price
        public ActionResult Index()
        {
            var prices = rs.Prices.ToList();

            return View(prices);
        }

        public ActionResult Create(Guid RateID)
        {
            Price price = new Price();
            price.RateID = RateID;
            //var date = DateTime.Now;
            //price.StartDate = date.Date;
            //price.EndDate = date.Date;
            return View(price);
        }

        [HttpPost]
        public ActionResult Create(Price model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ID = Guid.NewGuid();
                    ps.Add(model);
                    return RedirectToAction("Index", "Price");
                }

                return View(model);
            }
            catch (Exception e)
            {

                ViewBag.Error = e.InnerException;
                return View(model);
            }
        }


    }
}