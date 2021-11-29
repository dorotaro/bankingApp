using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public interface IAccountRepository
	{
		Task SaveAsync(AccountWriteModel accountWriteModel);

		Task<IEnumerable<AccountReadModel>> GetUserAccounts(Guid userId);

		Task<IEnumerable<AccountReadModel>> GetUserAccount(Guid accountId);
	}
}
