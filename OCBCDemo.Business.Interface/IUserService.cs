using OCBCDemo.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Interface
{
    public interface IUserService : IBaseService
    {
       CurrentUser GetUserInfoByNameAndPassword(string name, string password);
     }
}
