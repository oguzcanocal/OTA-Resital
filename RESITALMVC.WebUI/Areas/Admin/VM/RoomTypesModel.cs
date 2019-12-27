using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESITALMVC.WebUI.Areas.Admin.VM
{
    public class RoomTypesModel
    {
        public IEnumerable<Room> RoomsType { get; set; }
    }

    public class RoomTypesCreateModel
    {
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public int RoomAvailability { get; set; }
        public Guid HotelID { get; set; }
    }
}