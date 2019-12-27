using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.CORE.Entity
{
    public interface IEntity<T>
    {
        T ID { get; set; }
    }
}
