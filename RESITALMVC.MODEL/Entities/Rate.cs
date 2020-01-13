using RESITALMVC.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MODEL.Entities
{
    public class Rate:CoreEntity
    {
        public Guid RateID  { get; set; }
        public string RateName { get; set; }
       

        public Guid RoomID { get; set; }
        public virtual Room Rooms   { get; set; }
        public virtual List<Price2> Price { get; set; }


    }
}
