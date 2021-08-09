using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Interface
{
    public interface ITransactionService : IBaseService
    {
        string Transfer(Guid accountId, string recipientEmail, decimal transferAmount);

        string Deposit(Guid accountId, decimal amount);

    }
}
