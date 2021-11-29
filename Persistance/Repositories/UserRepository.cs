using Persistence.Clients;
using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
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
			var query = "INSERT INTO user (Id, Email, DateCreated) VALUES (@Id, @Email, @DateCreated)";

			await _sqlClient.Query<UserWriteModel>(query, userWriteModel);
		}

		public async Task<UserReadModel> GetUserByEmail(string email)
		{
			var query = $"SELECT * FROM user WHERE email=@email";

			var param = new
			{
				email = email
			};

			var user = await _sqlClient.Query<UserReadModel>(query, param);

			return user.FirstOrDefault();

		}
	}
}
