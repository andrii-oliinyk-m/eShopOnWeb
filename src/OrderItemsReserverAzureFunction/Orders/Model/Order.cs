using System;
using System.Collections.Generic;

namespace OrderItemsReserverAzureFunction.Orders
{
	public class Order
	{
		public int Id { get; set; }

		public string BuyerId { get; private set; }
		public DateTimeOffset OrderDate { get; set; }
		public Address ShipToAddress { get; set; }

		public readonly List<OrderItem> OrderItems = new List<OrderItem>();
	}
}
