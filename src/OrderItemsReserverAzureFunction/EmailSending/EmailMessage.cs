using OrderItemsReserverAzureFunction.Orders;

namespace OrderItemsReserverAzureFunction.EmailSending
{
	public class EmailMessage
	{
		public string To { get; set; }
		public string Subject { get; set; }
		public Order Order { get; set; }
	}
}
