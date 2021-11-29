using System.Threading.Tasks;

namespace Persistence.Clients
{
	public interface IFirebaseClient
	{
		Task<T2> RegisterAsync<T1, T2>(T1 registerWriteModel);

		Task<T2> LoginAsync<T1, T2>(T1 loginWriteModel);
	}
}
