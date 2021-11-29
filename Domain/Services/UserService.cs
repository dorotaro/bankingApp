using Contracts.Response;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace Domain.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserResponseModel> GetUserByEmail(string email)
		{
			var user = await _userRepository.GetUserByEmail(email);

			if (user != null)
			{
				return new UserResponseModel
				{
					Email = user.Email,
					Id = user.Id
				};
			}
			return null;
		}
	}
}
