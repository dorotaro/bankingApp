using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Clients
{
	public interface ISqlClient
	{
		Task Execute<T>(string query, object param);

		Task<IEnumerable<T>> Query<T>(string query, object param);


	}
}
