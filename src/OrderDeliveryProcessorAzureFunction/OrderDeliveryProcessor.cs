using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderDeliveryProcessorAzureFunction.Configuration;
using OrderDeliveryProcessorAzureFunction.Orders;
using OrderDeliveryProcessorAzureFunction.Orders.Model;

namespace OrderDeliveryProcessorAzureFunction
{
	public static class OrderDeliveryProcessor
	{
		[FunctionName("OrderDeliveryProcessor")]
		public static async Task<IActionResult> Run(
		[HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
		ILogger log)
		{
			try
			{
				var order = new JsonSerializer().Deserialize<Order>(
					new JsonTextReader(new StreamReader(req.Body)));

				await new OrdersRepository(new CosmosDbConfiguration()).Create(order);

				return new OkResult();
			}
			catch (Exception exception)
			{
				return new BadRequestObjectResult($"{exception.Message}\n\n{exception.StackTrace}");
			}
		}
	}
}
