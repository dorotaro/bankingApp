using Persistance.Clients;
using Persistance.Models.ReadModels;
using Persistance.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly ISqlClient _sqlClient;
		public TransactionRepository(ISqlClient sqlClient)
		{
			_sqlClient = sqlClient;
		}

		public async Task<IEnumerable<TransactionReadModel>> GetIncomingAccountTransactions(Guid receiverAccountNumberId)
		{
			var query = "Select * From transaction Where ReceiverAccountNumberId=@receiverAccountNumberId AND TransactionType!='Transfer' AND TransactionType='IncomingPayment'";

			var param = new { ReceiverAccountNumberId = receiverAccountNumberId };

			return await _sqlClient.Query<TransactionReadModel>(query, param);
		}

		public async Task<IEnumerable<TransactionReadModel>> GetOutgoingAccountTransactions(Guid senderAccountNumberId)
		{
			var query = "Select * From transaction Where SenderAccountNumberId=@senderAccountNumberId AND TransactionType!='Transfer' AND TransactionType='OutgoingPayment'";

			var param = new { SenderAccountNumberId = senderAccountNumberId };

			return await _sqlClient.Query<TransactionReadModel>(query, param);
		}

		public async Task<IEnumerable<TransactionReadModel>> GetTopUpTransactions(Guid receiverAccountNumberId, Guid senderAccountNumberId)
		{
			var query = "Select * From transaction Where ReceiverAccountNumberId=@receiverAccountNumberId AND SenderAccountNumberId=@senderAccountNumberId AND TransactionType='Transfer'";

			var param = new 
			{
				ReceiverAccountNumberId = receiverAccountNumberId,
				SenderAccountNumberId = senderAccountNumberId

			};

			return await _sqlClient.Query<TransactionReadModel>(query, param);
		}

		public async Task CreateTransaction(TransactionWriteModel transactionWriteModel)
		{
			var query = "INSERT INTO transaction (Id, SenderAccountNumberId, ReceiverAccountNumberId, Currency, TransactionType, Amount, DateCreated) VALUES (@Id, @SenderAccountNumberId,@ReceiverAccountNumberId , @Currency, @TransactionType, @Amount, @DateCreated)";

			await _sqlClient.Query<UserWriteModel>(query, transactionWriteModel);
		}
	}
}
