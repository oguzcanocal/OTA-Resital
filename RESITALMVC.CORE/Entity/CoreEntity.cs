using RESITALMVC.CORE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.CORE.Entity
{
     public class CoreEntity:IEntity<Guid>
    {
        public CoreEntity()
        {
            this.Status = Status.Actived;
            this.CreatedDate = DateTime.Now;
        }

        public Guid ID { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate  { get; set; }
        public string CreatedIP { get; set; }
        public string ModifiedIP { get; set; }


    }
}
