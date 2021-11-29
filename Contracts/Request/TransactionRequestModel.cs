using Contracts.Enums;
using System;

namespace Contracts.Request
{
	public class TransactionRequestModel
	{
		public Guid SenderAccountNumberId { get; set; }

		public Guid ReceiverAccountNumberId { get; set; }

		public Currency Currency { get; set; }

		public decimal Amount { get; set; }
	}
}
