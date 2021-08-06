using System.Threading.Tasks;

namespace OrderItemsReserverAzureFunction.Orders
{
	public interface IOrdersBlobRepository
	{
		Task SaveAsync(Order order, string blobName);
	}
}