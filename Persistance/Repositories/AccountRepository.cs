using Persistance.Clients;
using Persistance.Models.ReadModels;
using Persistance.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ISqlClient _sqlClient;
		public AccountRepository(ISqlClient sqlClient)
		{
			_sqlClient = sqlClient;
		}

		public async Task<IEnumerable<AccountReadModel>> GetUserAccount(Guid id)
		{
			var query = "Select * From account Where Id=@id";

			var param = new { Id = id };

			return await _sqlClient.Query<AccountReadModel>(query, param);
		}

		public async Task<IEnumerable<AccountReadModel>> GetUserAccounts(Guid userId)
		{
			var query = "Select * From account Where Userid =@userId";

			var param = new { UserId = userId };

			return await _sqlClient.Query<AccountReadModel>(query, param);
		}

		public async Task SaveAsync(AccountWriteModel accountWriteModel)
		{
			var query = "INSERT INTO account (Id, UserId, Currency, DateCreated) VALUES (@Id, @UserId,@Currency, @DateCreated)";

			await _sqlClient.Query<UserWriteModel>(query, accountWriteModel);
		}
	}
}
