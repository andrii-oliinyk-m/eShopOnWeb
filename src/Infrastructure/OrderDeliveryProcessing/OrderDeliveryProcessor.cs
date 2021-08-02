using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.Infrastructure.OrderDeliveryProcessing
{
	public class OrderDeliveryProcessor<T>: IOrderDeliveryProcessor<T>
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OrderDeliveryProcessor(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
		}

		public async Task<bool> SaveDocAsync(T obj)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient("OrderDeliveryProcessorHttpClient");
			HttpResponseMessage response = await httpClient.PostAsync("api/OrderDeliveryProcessor", new StringContent(obj.ToJson()));

			return response.IsSuccessStatusCode;
		}
	}
}
