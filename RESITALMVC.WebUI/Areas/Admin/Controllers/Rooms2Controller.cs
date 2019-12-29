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
    public class Rooms2Controller : Controller
    {
        RoomService rs = new RoomService();
        ResitalContext context = new ResitalContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listing(Guid HotelID)
        {
            RoomTypesModel model = new RoomTypesModel();

            model.RoomsType = rs.GetAllRooms().Where(x => x.HotelID == HotelID);

            return PartialView("_RoomListing", model);
        }


        public PartialViewResult ActionCreate(Guid HotelID)
        {

            RoomTypesCreateModel model = new RoomTypesCreateModel();
            model.HotelID = HotelID;

            return PartialView("_ActionCreatePW",model);
        }

        [HttpPost]
        public JsonResult  ActionCreate(Room model)
        {
            JsonResult json = new JsonResult();

            Room room = new Room();
            room.ID = Guid.NewGuid();
            room.RoomName = model.RoomName;
            room.RoomDescription = model.RoomDescription;
            room.RoomAvailability = model.RoomAvailability;
            room.HotelID = model.HotelID;

            

            var result = rs.SaveRoom(room);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Oda eklenemedi." };
            }

            return json;
        }

        public ActionResult Edit(Guid id)
        {
            Room room = context.Rooms.Find(id);
            

            return View(room);
        }


        [HttpPost]
        public ActionResult Edit(Room model)
        {
            
            context.Entry(model).State = EntityState.Modified;
            

            context.SaveChanges();
            return RedirectToAction("Index", "Rooms2", new { model.HotelID });
        }


        public ActionResult Delete(Guid id)
        {
            Room room = context.Rooms.Find(id);

            return View(room);
        }

        public ActionResult DeleteConfirm(Guid id)
        {
            Room room = context.Rooms.Find(id);
            context.Rooms.Remove(room);
            context.SaveChanges();
            return RedirectToAction("Index", "Rooms2", new { room.HotelID });
        }

    }

}
