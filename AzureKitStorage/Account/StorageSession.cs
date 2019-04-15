using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;

namespace AzureKitStorage.Account
{
    public static class StorageSession
    {
        public static CloudStorageAccount CreateStorageProvider(string connection)
        {
            return CloudStorageAccount.Parse(connection);
        }

        public static async Task<CloudBlobContainer> CreateContainerAsync(this CloudStorageAccount cloudStorageAccount, string queueName)
        {
            var container = cloudStorageAccount.CreateCloudBlobClient().GetContainerReference(queueName);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        public static async Task<CloudFileShare> CreateFileStorageAsync(this CloudStorageAccount cloudStorageAccount, string sharedName)
        {
            var container = cloudStorageAccount.CreateCloudFileClient().GetShareReference(sharedName);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        public static async Task<CloudQueue> CreateStorageQueuAsync(this CloudStorageAccount cloudStorageAccount, string queueName)
        {
            var container = cloudStorageAccount.CreateCloudQueueClient().GetQueueReference(queueName);
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