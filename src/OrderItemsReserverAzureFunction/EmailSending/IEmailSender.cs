using OrderItemsReserverAzureFunction.Orders;
using System.Threading.Tasks;

namespace OrderItemsReserverAzureFunction.EmailSending
{
	public interface IEmailSender
	{
		Task SendEmailAsync(Order order);
	}
}