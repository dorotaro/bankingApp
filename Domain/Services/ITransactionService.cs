using Contracts.Request;
using System;
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
