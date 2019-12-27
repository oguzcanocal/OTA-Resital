using RESITALMVC.CORE.Entity;
using RESITALMVC.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MODEL.Entities
{
    public class Hotel:CoreEntity
    {   
        public int HotelCode { get; set; }
        public string HotelName { get; set; }
        public string HotelAdress { get; set; }

        public virtual List<Room> Rooms { get; set; }


    }

}
