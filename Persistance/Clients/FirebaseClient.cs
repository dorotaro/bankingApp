using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.Clients
{
	public class FirebaseClient : IFirebaseClient
	{
    private readonly HttpClient _httpClient;

    public FirebaseClient(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    public async Task<T2> LoginAsync<T1, T2>(T1 loginWriteModel)
    {

      var uri = $"/accounts:signInWithPassword" + GetApiKey();
      var request = new HttpRequestMessage
      {
        Method = HttpMethod.Post,
        RequestUri = new Uri(_httpClient.BaseAddress + uri),
        Content = new StringContent(JsonSerializer.Serialize(loginWriteModel), Encoding.UTF8, "application/json")
      };


      var response = await _httpClient.SendAsync(request);

      var model = await response.Content.ReadAsStringAsync();

      return JsonSerializer.Deserialize<T2>(model);
    }

    public async Task<T2> RegisterAsync<T1, T2>(T1 registerWriteModel)
    {

      var uri = $"/accounts:signUp" + GetApiKey();
      var request = new HttpRequestMessage
      {
        Method = HttpMethod.Post,
        RequestUri = new Uri(_httpClient.BaseAddress + uri),
        Content = new StringContent(JsonSerializer.Serialize(registerWriteModel), Encoding.UTF8, "application/json")
      };


      var response = await _httpClient.SendAsync(request);

      var model = await response.Content.ReadAsStringAsync();

      return JsonSerializer.Deserialize<T2>(model);
    }

    private string GetApiKey()
    {
      var key = "";
      var something = _httpClient.DefaultRequestHeaders.GetValues("key");

      using (IEnumerator<string> iter = something.GetEnumerator())
      {
        iter.MoveNext();
        key = iter.Current;
      }

      return "?key=" + key;
    }
  }
}
