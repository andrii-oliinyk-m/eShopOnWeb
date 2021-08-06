using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderItemsReserverAzureFunction.Configuration;

namespace OrderItemsReserverAzureFunction.Orders
{
	public class OrdersBlobRepository : IOrdersBlobRepository
	{
		private readonly BlobServiceClient _blobServiceClient;
		private readonly string _containerName;
		public OrdersBlobRepository(BlobStorageConfiguration config)
		{
			var options = new BlobClientOptions();
			options.Retry.Mode = RetryMode.Exponential;
			options.Retry.MaxRetries = 3;
			_blobServiceClient = new BlobServiceClient(config.StorageAccountConnectionString, options);

			_containerName = config.OrderContainerName;
		}

		public async Task SaveAsync(Order order, string blobName)
		{
			BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
			await containerClient.CreateIfNotExistsAsync();

			BlobClient blob = containerClient.GetBlobClient(blobName);

			using (MemoryStream messageBites = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(order))))
			{
				await blob.UploadAsync(messageBites);
			}
		}
	}

}
