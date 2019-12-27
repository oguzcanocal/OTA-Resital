using RESITALMVC.CORE.Entity;
using RESITALMVC.CORE.Map;
using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MAP.Map
{
    public class RoomMap:CoreMap<Room>
    {
        public RoomMap()
        {
            ToTable("dbo.Rooms");
            Property(i => i.RoomName).IsOptional();
            Property(i => i.RoomDescription).IsOptional();
            Property(i => i.RoomAvailability).IsOptional();


            
        }
    }
}
