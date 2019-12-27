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
    public class HotelService:BaseService<Hotel>
    {
        public bool CheckHotel(string _hotelName)
        {
            return Any(x => x.HotelName == _hotelName);
        }

        public Hotel GetHotel(Guid id)
        {
            var context = new ResitalContext();

            return context.Hotels.Find(id);
        }

    }
}
