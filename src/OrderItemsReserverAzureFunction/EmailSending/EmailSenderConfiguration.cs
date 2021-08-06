using System;

namespace OrderItemsReserverAzureFunction.EmailSending
{
	public class EmailSenderConfiguration
	{
		public string LogicAppUri =>
			Environment.GetEnvironmentVariable("LOGIC_APP_URI", EnvironmentVariableTarget.Process);
		public string EmailAddress =>
			Environment.GetEnvironmentVariable("EMAIL_ADDRESS", EnvironmentVariableTarget.Process);
	}
}
