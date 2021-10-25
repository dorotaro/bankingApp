using Persistance.Models.ReadModels;
using Persistance.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public interface ITransactionRepository
	{
		Task CreateTransaction(TransactionWriteModel transactionWriteModel);

		Task<IEnumerable<TransactionReadModel>> GetIncomingAccountTransactions(Guid receiverAccountNumberId);

		Task<IEnumerable<TransactionReadModel>> GetOutgoingAccountTransactions(Guid senderAccountNumberId);

		Task<IEnumerable<TransactionReadModel>> GetTopUpTransactions(Guid receiverAccountNumberId, Guid senderAccountNumberId);
	}
}
