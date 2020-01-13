using RESITALMVC.DAL.Context;
using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.SERVICE.Option
{
    public class PriceService:BaseService<Price2>
    {
        public IEnumerable<Price2> GetAllPrice()
        {
            var context = new ResitalContext();
            return context.Prices2.ToList();
        }
    }
}
