using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;

namespace AzureKitStorage
{
    public class BlobStorageProvider
    {
        private readonly CloudBlobClient account; 
        
        public BlobStorageProvider(CloudBlobClient account)
        {
            this.account = account;
        }

        private async Task<CloudBlobContainer> GetContainerAsync(string name)
        { 
            var container = this.account.GetContainerReference(name);  
            await container.CreateIfNotExistsAsync(); 
            return container;     
        }

        public async Task<Uri> UploadLargeFile(string containerName, string blobName, string filename) 
        { 
            var container = await this.GetContainerAsync(containerName);
            var blobObj = container.GetBlockBlobReference(blobName);            
            await blobObj.UploadFromFileAsync(filename);
            return blobObj.Uri;
        }

        public async Task<Uri> UploadFile(string containerName, string blobName, string filename) 
        { 
            var container = await this.GetContainerAsync(containerName);
            var blobObj = container.GetPageBlobReference(blobName);            
            await blobObj.UploadFromFileAsync(filename);
            return blobObj.Uri;
        }
    }
}
