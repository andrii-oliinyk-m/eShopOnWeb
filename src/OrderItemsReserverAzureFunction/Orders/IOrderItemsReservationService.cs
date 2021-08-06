using System.Threading.Tasks;

namespace OrderItemsReserverAzureFunction.Orders
{
	public interface IOrderItemsReservationService
	{
		Task SaveAsync(Order order);
	}
}