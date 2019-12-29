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
        public string RateName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? AdultPrice { get; set; }
        public double? KidPrice { get; set; }

        public Guid RoomID { get; set; }
        public virtual Room Rooms   { get; set; }

    }
}
