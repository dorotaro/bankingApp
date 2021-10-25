using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Persistance.Models.ReadModels
{
	public class TransactionReadModel
	{
		[JsonPropertyName("senderAccountNumberId")]
		public Guid SenderAccountNumberId { get; set; }

		[JsonPropertyName("receiverAccountNumberId")]
		public Guid ReceiverAccountNumberId { get; set; }

		[JsonPropertyName("currency")]
		public string Currency { get; set; }

		[JsonPropertyName("transactionType")]
		public string TransactionType { get; set; }

		[JsonPropertyName("amount")]
		public decimal Amount { get; set; }
	}
}
