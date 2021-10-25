using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
