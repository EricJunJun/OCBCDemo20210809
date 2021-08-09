using OCBCDemo.Business.DataAccess;
using OCBCDemo.Business.Common.Utility.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Entity
{
    public class CurrentUser
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public decimal? PhoneNumber { get; set; }
        public decimal? Balance { get; set; }
        public DateTime LastLoginDate { get; set; }
        public CustomPageModel<TransferHistory> TransferHistory { get; set; }
    }
}
