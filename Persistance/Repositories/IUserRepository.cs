using Persistance.Models.ReadModels;
using Persistance.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public interface IUserRepository
	{
		Task SaveAsync(UserWriteModel userWriteModel);

		Task<UserReadModel> GetUserByEmail(string email);
	}
}
