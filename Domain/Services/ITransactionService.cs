using Contracts.Request;
using Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
	public interface ITransactionService
	{
		Task TopUpAccount(TransactionRequestModel transactionRequestModel);

		Task CreatePayment (TransactionRequestModel transactionRequestModel);

		Task<decimal> GetAccountBalance (Guid accountId);
	}
}
