using Persistance.Clients;
using Persistance.Models.ReadModels;
using Persistance.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ISqlClient _sqlClient;
		public UserRepository(ISqlClient sqlClient)
		{
			_sqlClient = sqlClient;
		}
		public async Task SaveAsync(UserWriteModel userWriteModel)
		{
			var query = "INSERT INTO user (Id, Email, DateCreated) VALUES (@Id," +
			"@Email,@DateCreated)";

			await _sqlClient.Query<UserWriteModel>(query, userWriteModel);
		}

		public async Task<UserReadModel> GetUserByEmail(string email)
		{
			var query = $"SELECT * from user Where email=@email";

			var param = new
			{
				email = email
			};

			var user = await _sqlClient.Query<UserReadModel>(query, param);

			return user.FirstOrDefault();

		}
	}
}
