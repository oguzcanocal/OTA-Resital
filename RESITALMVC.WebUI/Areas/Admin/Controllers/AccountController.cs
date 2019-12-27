using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESITALMVC.WebUI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        UserService db;
        public AccountController()
        {
            if (db == null)
            {
                db = new UserService();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            try
            {
                if (model.Password != null && model.Username != string.Empty)
                {
                    if (db.CheckUser(model.Username, model.Password))
                    {
                        var user = db.GetByDefault(x => x.Username == model.Username);
                        Session["Login"] = user;
                        var userDetail = Session["Login"] as User;
                        TempData["User"] = userDetail.Username;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Error"] = "Giriş bilgileriniz hatalıdır.";
                    }
                }
                else
                {
                    TempData["Error1"] = "Lütfen kullanıcı adınızı giriniz.";
                    TempData["Error2"] = "Lütfen şifrenizi giriniz.";
                }
            }
            catch (Exception ex)
            {   

                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Login");

        }






        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        public ActionResult RegisterComplete(User model)
        {
            if (ModelState.IsValid)
            {
                if(db.Any(x => x.Username == model.Username))
                {
                    ViewBag.ExistUser = "Üye adı daha önce alınmıştır";
                }
                else if(db.Any(x => x.Email == model.Email))
                {
                    ViewBag.ExistMail = "Mail adresi daha önce alınmıştır";
                }
                else
                {
                    model.ID = Guid.NewGuid();
                    model.Roles = MODEL.Enum.Role.User;
                    model.ActivationCode = Guid.NewGuid();
                    model.IsActive = false;
                    db.Add(model);
                }
            }

            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Complete(Guid id)
        {
            if(db.Any(x => x.ActivationCode == id))
            {
                User activeUser = db.GetByDefault(x => x.ActivationCode == id);
                activeUser.IsActive = true;
                activeUser.ActivationCode = Guid.NewGuid();
                db.Update(activeUser);
                ViewBag.ActivationStatus = 1;
            }
            else
            {
                ViewBag.ActivationStatus = 0;
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("login");
            return RedirectToAction("Index");
        }


    }

    
}