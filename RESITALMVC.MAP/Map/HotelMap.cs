using RESITALMVC.CORE.Map;
using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MAP.Map
{
    public class HotelMap:CoreMap<Hotel>
    {
        public HotelMap()
        {
            ToTable("dbo.Hotels");
            Property(i => i.HotelCode).IsOptional();
            Property(i => i.HotelName).IsOptional();
            Property(i => i.HotelAdress).IsOptional();




        }

    }
}
