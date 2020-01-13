using RESITALMVC.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MODEL.Entities
{
    public class Price2:CoreEntity
    {
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public double AdultPrice { get; set; }
        public double KidPrice { get; set; }


        public Guid RateID { get; set; }
        public virtual Rate Rate { get; set; }
    }
}
