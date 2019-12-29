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
    public class RateService:BaseService<Rate>
    {
        public IEnumerable<Rate> GetAllRate()
        {
            var context = new ResitalContext();
            return context.Rates.ToList();
        }

        public bool SaveRate(Rate rate)
        {
            var context = new ResitalContext();

            context.Rates.Add(rate);

            return context.SaveChanges() > 0;
        }

    }
}
