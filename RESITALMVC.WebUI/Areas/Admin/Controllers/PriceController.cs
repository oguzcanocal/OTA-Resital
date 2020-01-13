using RESITALMVC.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESITALMVC.WebUI.Areas.Admin.Controllers
{
    public class PriceController : Controller
    {
        ResitalContext rs = new ResitalContext();
        // GET: Admin/Price
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPrices()
        {
            var prices = rs.Prices2.ToList();
            return new JsonResult { Data = prices, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}