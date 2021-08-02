using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
	public interface IOrderDeliveryProcessor<T>
	{
		Task<bool> SaveDocAsync(T obj);
	}
}
