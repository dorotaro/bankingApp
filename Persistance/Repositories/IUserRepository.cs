using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public interface IUserRepository
	{
		Task SaveAsync(UserWriteModel userWriteModel);

		Task<UserReadModel> GetUserByEmail(string email);
	}
}
