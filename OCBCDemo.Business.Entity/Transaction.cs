using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Entity
{
    //public class Transactions
    //{
    //    public Transactions()
    //    {
    //        TransactionList = new List<Transaction>();
    //    }
    //    public Guid AccountId { get; set; }
    //    public string Name { get; set; }
    //    public string Password { get; set; }

    //    [DataType(DataType.EmailAddress)]
    //    [Display(Name = "E-mail")]
    //    public string Email { get; set; }
    //    public decimal? PhoneNumber { get; set; }
    //    public decimal? Balance { get; set; }
    //    public DateTime LastLoginDate { get; set; }
    //    public List<Transaction> TransactionList { get; set; }
    //}

    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid RecipientId { get; set; }
        public string RecipientEmail { get; set; }
        public DateTime TransferDate { get; set; }

        public decimal TransferAmount { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
