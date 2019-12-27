using RESITALMVC.CORE.Map;
using RESITALMVC.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MAP.Map
{
    public class UserMap:CoreMap<User>
    {
        public UserMap()
        {
            ToTable("dbo.Users");
            Property(i => i.Username).IsRequired().HasColumnName("Kullanıcı Adı");
            Property(i => i.Password).IsRequired().HasColumnName("Şifre");
            Property(i => i.Email).IsRequired().HasColumnName("Mail");
            Property(i => i.Status).IsRequired().HasColumnName("Status");
            Property(i => i.Roles).IsOptional().HasColumnName("Role");

            Ignore(i => i.ConfirmPassword);
        }
    }
}
