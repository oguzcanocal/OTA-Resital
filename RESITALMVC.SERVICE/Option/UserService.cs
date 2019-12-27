using RESITALMVC.MODEL.Entities;
using RESITALMVC.SERVICE.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.SERVICE.Option
{
    public class UserService:BaseService<User>
    {
        public bool CheckUser(string _username, string _password)
        {
            return Any(x => x.Username == _username && x.Password == _password && x.IsActive == true);
        }
    }
}
