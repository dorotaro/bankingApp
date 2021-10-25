using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Request
{
	public class AccountCreateRequestModel
	{
		public Currency Currency { get; set; }

		public Guid UserId { get; set; }
	}
}
