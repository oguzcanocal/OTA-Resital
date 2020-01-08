using RESITALMVC.CORE.Map;
using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MAP.Map
{
    public class PriceMap:CoreMap<Price>
    {
        public PriceMap()
        {
            Property(x => x.AdultPrice).IsOptional();
            Property(x => x.KidPrice).IsOptional();
            Property(x => x.StartDate).IsRequired();
            Property(x => x.EndDate).IsRequired();
        }
    }
}
