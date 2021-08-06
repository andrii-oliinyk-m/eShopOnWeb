using System;
using System.Web;

namespace OrderItemsReserverAzureFunction.Orders
{
	public class OrderBlobNameProvider : IOrderBlobNameProvider
	{
		public string CreateName(Order order)
		{
			string blobName = $"order-{order.BuyerId?.ToLower()}-{order.OrderDate:yyyy-MM-dd}-{DateTime.UtcNow.Ticks.ToString().Substring(3)}.json";
			string encodedBlobName = HttpUtility.UrlEncode(blobName);
			return encodedBlobName;
		}
	}
}
