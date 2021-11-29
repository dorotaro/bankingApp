using Contracts.Enums;
using Contracts.Request;
using Persistence.Models.WriteModels;
using Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class TransactionService : ITransactionService
	{
		private readonly ITransactionRepository _transactionRepository;

		public TransactionService(ITransactionRepository transactionRepository)
		{
			_transactionRepository = transactionRepository;
		}

		public async Task CreatePayment(TransactionRequestModel transactionRequestModel)
		{
			var outgoingTransaction = new TransactionWriteModel
			{
				Id = Guid.NewGuid(),
				SenderAccountNumberId = transactionRequestModel.SenderAccountNumberId,
				ReceiverAccountNumberId = transactionRequestModel.ReceiverAccountNumberId,
				Amount = transactionRequestModel.Amount,
				Currency = transactionRequestModel.Currency.ToString(),
				TransactionType = TransactionType.OutgoingPayment.ToString(),
				DateCreated = DateTime.UtcNow
			};

			await _transactionRepository.CreateTransaction(outgoingTransaction);

			var incomingTransaction = new TransactionWriteModel
			{
				Id = Guid.NewGuid(),
				SenderAccountNumberId = transactionRequestModel.SenderAccountNumberId,
				ReceiverAccountNumberId = transactionRequestModel.ReceiverAccountNumberId,
				Amount = transactionRequestModel.Amount,
				Currency = transactionRequestModel.Currency.ToString(),
				TransactionType = TransactionType.IncomingPayment.ToString(),
				DateCreated = DateTime.UtcNow
			};

			await _transactionRepository.CreateTransaction(incomingTransaction);
		}

		public async Task<decimal> GetAccountBalance(Guid accountId)
		{
			var incomingTransactions = await _transactionRepository.GetIncomingAccountTransactions(accountId);

			var outgoingTransactions = await _transactionRepository.GetOutgoingAccountTransactions(accountId);

			var topUps = await _transactionRepository.GetTopUpTransactions(accountId, accountId);

			decimal incomingTransactionsSum = 0;

			decimal outgoingTransactionsSum = 0;

			decimal topUpsSum = 0;

			foreach (var incomingTransaction in incomingTransactions)
			{
				incomingTransactionsSum += incomingTransaction.Amount;
			}

			foreach (var outgoingTransaction in outgoingTransactions)
			{
				outgoingTransactionsSum += outgoingTransaction.Amount;
			}

			foreach (var topUp in topUps)
			{
				topUpsSum += topUp.Amount;
			}

			return incomingTransactionsSum + topUpsSum - outgoingTransactionsSum;
		}

		public async Task TopUpAccount(TransactionRequestModel transactionRequestModel)
		{
			var transactionWriteModel = new TransactionWriteModel
			{
				Id = Guid.NewGuid(),
				SenderAccountNumberId = transactionRequestModel.SenderAccountNumberId,
				ReceiverAccountNumberId = transactionRequestModel.ReceiverAccountNumberId,
				Amount = transactionRequestModel.Amount,
				Currency = transactionRequestModel.Currency.ToString(),
				TransactionType = TransactionType.Transfer.ToString(),
				DateCreated = DateTime.UtcNow
			};

			await _transactionRepository.CreateTransaction(transactionWriteModel);

		}
	}
}
