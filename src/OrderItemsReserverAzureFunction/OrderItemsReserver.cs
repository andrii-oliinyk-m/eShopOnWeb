using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderItemsReserverAzureFunction.Configuration;
using OrderItemsReserverAzureFunction.EmailSending;
using OrderItemsReserverAzureFunction.Orders;

namespace OrderItemsReserverAzureFunction
{
	public static class OrderItemsReserver
	{

		private static HttpClient _httpClient = new HttpClient();

		[FunctionName("OrderItemsReserver")]
		public static async Task Run(
			[ServiceBusTrigger("%SERVICE_BUS_QUEUE_NAME%", Connection = "SERVICE_BUS_CONNECTION_STRING")]string myQueueItem, 
			ILogger logger)
		{
			IOrderItemsReservationService orderItemsReservationService =
				new OrderItemsReservationService(
					new OrderBlobNameProvider(),
					new OrdersBlobRepository(
						new BlobStorageConfiguration()),
					new EmailSender(
						new EmailSenderConfiguration(),
						_httpClient));

			Order order = JsonConvert.DeserializeObject<Order>(myQueueItem);
			await orderItemsReservationService.SaveAsync(order);
		}
	}
}
