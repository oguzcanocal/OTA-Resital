using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESITALMVC.WebUI.Areas.Admin.VM
{
    public class PriceTypesModel
    {
        public IEnumerable<Price2> PriceTypes{ get; set; }
    }

    public class PriceTypesCreateModel
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double AdultPrice { get; set; }
        public double KidPrice { get; set; }
    }
}