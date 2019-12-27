using RESITALMVC.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MODEL.Entities
{
    public class Room:CoreEntity
    {

        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public int RoomAvailability { get; set; }

        public Guid HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}
