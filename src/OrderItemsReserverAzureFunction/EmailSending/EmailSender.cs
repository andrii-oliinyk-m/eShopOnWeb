using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OrderItemsReserverAzureFunction.Orders;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OrderItemsReserverAzureFunction.EmailSending
{
	public class EmailSender : IEmailSender
	{
		private readonly HttpClient _httpClient;
		private readonly string _logicAppUri;
		private readonly string _emailAddress;

		public EmailSender(EmailSenderConfiguration config, HttpClient httpClient)
		{
			_httpClient = httpClient;
			_logicAppUri = config.LogicAppUri;
			_emailAddress = config.EmailAddress;
		}

		public async Task SendEmailAsync(Order order)
		{
			var emailMessage = new EmailMessage
			{
				To = _emailAddress,
				Subject = $"Reservation of order items failed. Order Id is {order.Id} with {order.OrderItems.Count} item(s).",
				Order = order
			};

			await _httpClient.PostAsync(_logicAppUri, 
				new StringContent(JsonConvert.SerializeObject(emailMessage), 
					Encoding.UTF8, 
					"application/json"));
		}
	}
}
