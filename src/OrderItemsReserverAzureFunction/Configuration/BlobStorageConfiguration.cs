using System;

namespace OrderItemsReserverAzureFunction.Configuration
{
	public class BlobStorageConfiguration
	{
		public string StorageAccountConnectionString =>
			Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_CONNECTION_STRING", EnvironmentVariableTarget.Process);

		public string OrderContainerName =>
			Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_CONTAINER_NAME", EnvironmentVariableTarget.Process);
	}
}
