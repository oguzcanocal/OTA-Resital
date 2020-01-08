using RESITALMVC.CORE.Map;
using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MAP.Map
{
    public class RateMap:CoreMap<Rate>
    {
        public RateMap()
        {
            ToTable("dbo.Rates");
            Property(i => i.RateID).IsOptional();
            Property(i => i.RateName).IsOptional();


        }


    }
}
