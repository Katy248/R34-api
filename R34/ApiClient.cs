using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace R34;
public class ApiClient
{
	private HttpClient _httpClient = new HttpClient();
	public async Task<HttpContent> Execute(string url)
	{
		var response = await _httpClient.GetAsync(url);

		return response.Content;
	}
}
