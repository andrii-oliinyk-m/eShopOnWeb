using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.eShopWeb.Infrastructure.OrderItemsReservation
{
	public class OrderItemsReserver: IOrderItemsReserver
	{
		private readonly ServiceBusClient _client;
		private readonly ServiceBusSender _clientSender;

		public OrderItemsReserver(IOptions<OrderItemsReservationOptions> options)
		{
			_client = new ServiceBusClient(options.Value.ServiceBusConnectionString);
			_clientSender = _client.CreateSender(options.Value.QueueName);
		}

		public async Task ReserveOrder(Order order)
		{
			ServiceBusMessage message = new ServiceBusMessage(order.ToJson());
			await _clientSender.SendMessageAsync(message).ConfigureAwait(false);
		}
	}
}
