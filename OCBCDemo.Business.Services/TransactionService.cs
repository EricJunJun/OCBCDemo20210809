using OCBCDemo.Business.Interface;
using OCBCDemo.Business.Common.Utility.Pagination;
using OCBCDemo.Business.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        TransactionDataAccess _TransactionDA { get; set; }
        public TransactionService(DbContext context, TransactionDataAccess transactionDA) : base(context)
        {
            this._TransactionDA = transactionDA;
        }

        public string Transfer(Guid accountId, string recipientEmail, decimal transferAmount)
        {
            return _TransactionDA.Transfer(accountId,  recipientEmail,  transferAmount);
        }

        public string Deposit(Guid accountId, decimal amount)
        {
            return _TransactionDA.Deposit(accountId, amount);
        }

    }
}
