using RESITALMVC.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.CORE.Map
{
    public class CoreMap<T>:EntityTypeConfiguration<T>where T:CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("ID").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedIP).HasColumnName("CreatedIP").IsOptional();
            Property(x => x.ModifiedIP).HasColumnName("MofifiedIP").IsOptional();
        }
    }
}
