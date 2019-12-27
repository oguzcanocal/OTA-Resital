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
    public class RoomService:BaseService<Room>

        
    {
        public bool CheckRoom(string _RoomName)
        {
            return Any(x => x.RoomName == _RoomName);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            var context = new ResitalContext();

            return context.Rooms.ToList();

        }

        public bool SaveRoom(Room room)
        {
            var context = new ResitalContext();

            

            context.Rooms.Add(room);

            return context.SaveChanges() > 0;

        }

        
        
    }
}
