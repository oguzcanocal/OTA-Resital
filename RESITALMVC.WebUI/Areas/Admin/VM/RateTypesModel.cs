using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESITALMVC.WebUI.Areas.Admin.VM
{
    public class RateTypesModel
    {
        public IEnumerable<Rate> RateTypes { get; set; }
    }

    public class RateTypesCreateModel
    {
        public string RateName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AdultPrice { get; set; }
        public double KidPrice { get; set; }
        public Guid RoomID { get; set; }

    }
}