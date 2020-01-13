using RESITALMVC.MAP.Map;
using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RESITALMVC.DAL.Context
{
    public class ResitalContext:DbContext
    {
        public ResitalContext()
        {
            Database.Connection.ConnectionString = "server=.;database=Resital;uid=sa;pwd=123";
            Database.SetInitializer<ResitalContext>(new DropCreateDatabaseIfModelChanges<ResitalContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new HotelMap());
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new RateMap());
            modelBuilder.Configurations.Add(new PriceMap2());

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Price2> Prices2 { get; set; }
    }

    
}
