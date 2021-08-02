using System;
using System.Collections.Generic;

namespace OrderDeliveryProcessorAzureFunction.Orders.Model
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
