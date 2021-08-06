using OrderItemsReserverAzureFunction.EmailSending;
using System;
using System.Threading.Tasks;

namespace OrderItemsReserverAzureFunction.Orders
{
	public class OrderItemsReservationService : IOrderItemsReservationService
	{
		private readonly IOrderBlobNameProvider _orderBlobNameProvider;
		private readonly IOrdersBlobRepository _ordersBlobRepository;
		private readonly IEmailSender _emailSender;

		public OrderItemsReservationService(
			IOrderBlobNameProvider orderBlobNameProvider,
			IOrdersBlobRepository ordersBlobRepository,
			IEmailSender emailSender)
		{
			_orderBlobNameProvider = orderBlobNameProvider;
			_ordersBlobRepository = ordersBlobRepository;
			_emailSender = emailSender;
		}

		public async Task SaveAsync(Order order)
		{
			try
			{
				string blobName = _orderBlobNameProvider.CreateName(order);
				await _ordersBlobRepository.SaveAsync(order, blobName);
			}
			catch (Exception)
			{
				await _emailSender.SendEmailAsync(order);
			}
		}
	}
}
