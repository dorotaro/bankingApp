using Contracts.Response;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserService
	{
		Task<UserResponseModel> GetUserByEmail(string email);
	}
}
