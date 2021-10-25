using System;

namespace Persistance.Models.WriteModels
{
	public class TransactionWriteModel
	{
		public Guid Id { get; set; }

		public Guid SenderAccountNumberId { get; set; }

		public Guid ReceiverAccountNumberId { get; set; }

		public string Currency { get; set; }

		public string TransactionType { get; set; }

		public decimal Amount { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
