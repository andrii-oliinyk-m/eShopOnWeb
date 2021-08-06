namespace Microsoft.eShopWeb.Infrastructure.OrderItemsReservation
{
	public class OrderItemsReservationOptions
	{
		public static string ConfigurationSectionName = "OrderItemsReservationQueue";
		public string ServiceBusConnectionString { get; set; }
		public string QueueName { get; set; }
	}
}
