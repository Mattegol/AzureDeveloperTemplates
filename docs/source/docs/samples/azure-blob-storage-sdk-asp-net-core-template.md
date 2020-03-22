[Azure Storage Blobs SDK with ASP .NET Core Template](https://github.com/Daniel-Krzyczkowski/AzureDeveloperTemplates/tree/master/src/azure-blob-storage-sdk-asp-net-core-template/AzureDeveloperTemplates.BlobStorage)

Sample project to present how to use Azure Storage Blobs SDK to upload and downlad files from the Azure Blob Storage:

```csharp
    public class StorageService : IStorageService
    {
        private readonly BlobStorageSettings _blobStorageSettings;

        public StorageService(BlobStorageSettings blobStorageSettings)
        {
            _blobStorageSettings = blobStorageSettings;
        }

        public async Task DeleteBlobIfExistsAsync(string blobName)
        {
            var container = await GetBlobContainer();
            var blockBlob = container.GetBlobClient(blobName);
            await blockBlob.DeleteIfExistsAsync();
        }

        public async Task<bool> DoesBlobExistAsync(string blobName)
        {
            var container = await GetBlobContainer();
            var blockBlob = container.GetBlobClient(blobName);
            var doesBlobExist = await blockBlob.ExistsAsync();
            return doesBlobExist.Value;
        }

        public async Task DownloadBlobIfExistsAsync(Stream stream, string blobName)
        {
            var container = await GetBlobContainer();
            var blockBlob = container.GetBlobClient(blobName);

            var doesBlobExist = await blockBlob.ExistsAsync();

            if (doesBlobExist.Value == true)
            {
                await blockBlob.DownloadToAsync(stream);
            }
        }

        public async Task<string> GetBlobUrl(string blobName)
        {
            var container = await GetBlobContainer();
            var blockBlob = container.GetBlobClient(blobName);

            var exists = await blockBlob.ExistsAsync();

            if (exists)
            {
                return blockBlob.Uri.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task UploadBlobAsync(Stream stream, string blobName)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var container = await GetBlobContainer();

            BlobClient blob = container.GetBlobClient(blobName);
            await blob.UploadAsync(stream);
        }

        private async Task<BlobContainerClient> GetBlobContainer()
        {
            BlobContainerClient container = new BlobContainerClient(_blobStorageSettings.ConnectionString,
                                                                            _blobStorageSettings.ContainerName);

            await container.CreateIfNotExistsAsync();

            return container;
        }
    }
```