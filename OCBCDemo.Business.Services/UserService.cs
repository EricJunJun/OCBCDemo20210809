using OCBCDemo.Business.DataAccess;
using OCBCDemo.Business.Entity;
using OCBCDemo.Business.Interface;
using OCBCDemo.Business.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(DbContext context) : base(context)
        {
        }

        public CurrentUser GetUserInfoByNameAndPassword(string name, string password)
        {
            CurrentUser currentUser = null;
            string strSql = "select * from [User] where Name = @Name AND Password = @Password And IsDeleted = 0";
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@Name", name));
            listParameter.Add(new SqlParameter("@Password", password));
            var user = base.ExcuteQuery<User>(strSql, listParameter.ToArray()).FirstOrDefault();
            if (user != null)
            {
                currentUser = new CurrentUser();
                currentUser.AccountId = user.Id;
                currentUser.Name = user.Name;
                currentUser.Email = user.Email;
                currentUser.PhoneNumber = user.PhoneNumber;
                currentUser.Password = user.Password;
                currentUser.Balance = user.Balance;
                currentUser.LastLoginDate = DateTime.Now;
            }
           
            return currentUser;
        }
    }
}
