namespace OrderItemsReserverAzureFunction.Orders
{
	public interface IOrderBlobNameProvider
	{
		string CreateName(Order order);
	}
}