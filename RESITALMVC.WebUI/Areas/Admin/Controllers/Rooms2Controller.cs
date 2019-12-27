using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Option;
using RESITALMVC.WebUI.Areas.Admin.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESITALMVC.WebUI.Areas.Admin.Controllers
{
    public class Rooms2Controller : Controller
    {
        RoomService rs = new RoomService();
        HotelService hs = new HotelService();
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

    }

}
