namespace OrderDeliveryProcessorAzureFunction.Orders.Model
{
	public class OrderItem
	{
		public int Id { get; set; }
		public decimal UnitPrice { get; set; }
		public int Units { get; set; }
	}
}
