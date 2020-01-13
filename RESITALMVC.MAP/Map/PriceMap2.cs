using RESITALMVC.CORE.Map;
using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MAP.Map
{
    public class PriceMap2:CoreMap<Price2>
    {
        public PriceMap2()
        {
            ToTable("dbo.Prices2");
            Property(x => x.AdultPrice).IsRequired();
            Property(x => x.KidPrice).IsRequired();
            Property(x => x.StartDate).IsRequired();
            Property(x => x.EndDate).IsRequired();

        }
    }
}
