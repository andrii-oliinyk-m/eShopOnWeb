using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using OrderDeliveryProcessorAzureFunction.Configuration;
using OrderDeliveryProcessorAzureFunction.Orders.Model;

namespace OrderDeliveryProcessorAzureFunction.Orders
{
	public class OrdersRepository
	{
		private readonly string _databaseName;
		private readonly string _collectionName;

		private readonly DocumentClient _client;

		public OrdersRepository(CosmosDbConfiguration config)
		{
			_databaseName = config.DatabaseName;
			_collectionName = config.CollectionName;
			_client = new DocumentClient(new Uri(config.AccountEndpoint), config.AccountKey);
		}

		private async Task InitializeAsync()
		{
			await _client.CreateDatabaseIfNotExistsAsync(new Database { Id = _databaseName });
			await _client.CreateDocumentCollectionIfNotExistsAsync(
				UriFactory.CreateDatabaseUri(_databaseName),
				new DocumentCollection
				{
					Id = _collectionName,
					PartitionKey = new PartitionKeyDefinition
					{
						Paths = new Collection<string> { "/Id" }
					}
				});
		}

		public async Task Create(Order order)
		{
			await InitializeAsync();

			await _client.CreateDocumentAsync(
				UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName),
				order);
		}
	}
}

