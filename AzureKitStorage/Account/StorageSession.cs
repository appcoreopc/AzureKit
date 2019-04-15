using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace AzureKitStorage.Account
{
    public static class StorageSession
    {
        public static CloudStorageAccount CreateStorageProvider(string connection)
        {
            return CloudStorageAccount.Parse(connection);
        }

        public static async Task<CloudBlobContainer> CreateContainerAsync(this CloudStorageAccount cloudStorageAccount, string containerName)
        {
            var container = cloudStorageAccount.CreateCloudBlobClient().GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        public static ICloudBlob CreatePageStorage(this CloudBlobContainer container, string blobName)
        {
            return container.GetPageBlobReference(blobName);
        }

        public static ICloudBlob CreateBlockStorage(this CloudBlobContainer container, string blobName)
        {
            return container.GetBlockBlobReference(blobName);
        }

        public static ICloudBlob CreateAppendStorage(this CloudBlobContainer container, string blobName)
        {
            return container.GetAppendBlobReference(blobName);
        }
    }
}