using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureStorageKit.Provider
{
    class ContainerProvider
    {
        private readonly CloudBlobClient account;

        public ContainerProvider(CloudBlobClient account)
        {
            this.account = account;
        }

        private async Task<CloudBlobContainer> CreateContainerAsync(string name)
        {
            var container = this.account.GetContainerReference(name);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        public async Task<IList<Uri>> ListFiles(string containerName, string blobName, string filename)
        {
            var fileListing = new List<Uri>();
            var token = new BlobContinuationToken();

            do
            {
                var fileSegment = await this.account.ListBlobsSegmentedAsync(filename, token);

                foreach (var item in fileSegment.Results)
                {
                    fileListing.Add(item.Uri);
                }

            } while (token != null);

            return fileListing;
        }
    }
}
