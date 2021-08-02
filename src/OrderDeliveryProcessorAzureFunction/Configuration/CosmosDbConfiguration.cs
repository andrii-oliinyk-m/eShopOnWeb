using System;

namespace OrderDeliveryProcessorAzureFunction.Configuration
{
	public class CosmosDbConfiguration
	{
		public string AccountEndpoint =>
			Environment.GetEnvironmentVariable("COSMOSDB_ACCOUNT_ENDPOINT", EnvironmentVariableTarget.Process);

		public string AccountKey => 
			Environment.GetEnvironmentVariable("COSMOSDB_ACCOUNT_KEY", EnvironmentVariableTarget.Process);

		public string DatabaseName =>
			Environment.GetEnvironmentVariable("COSMOSDB_DATABASE_NAME", EnvironmentVariableTarget.Process);

		public string CollectionName =>
			Environment.GetEnvironmentVariable("COSMOSDB_COLLECTION_NAME", EnvironmentVariableTarget.Process);
	}
}
