using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;

namespace AzureKitStorage
{
    public class BlobStorageProvider
    {
        private readonly CloudBlobClient account; 

        private CloudBlobContainer container;

        
        public BlobStorageProvider(CloudBlobClient account)
        {
            this.account = account;
        }

        private async Task<CloudBlobContainer> CreateContainerAsync(string name)
        { 
            this.container = this.account.GetContainerReference(name);  
            await this.container.CreateIfNotExistsAsync(); 
            return this.container;     
        }

        private CloudPageBlob GetPageContainer(string blobName) { 
            return container.GetPageBlobReference(blobName);  
        }

        public async Task<Uri> UploadLargeFile(string containerName, string blobName, string filename) 
        { 
            var container = await this.CreateContainerAsync(containerName);
            var blobObj = container.GetBlockBlobReference(blobName);            
            await blobObj.UploadFromFileAsync(filename);
            return blobObj.Uri;
        }

        public async Task<Uri> UploadFile(string containerName, string blobName, string filename) 
        { 
            var container = await this.CreateContainerAsync(containerName);
            var blobObj = container.GetPageBlobReference(blobName);            
            await blobObj.UploadFromFileAsync(filename);
            return blobObj.Uri;
        }
        
        public void GetAccessUrl(string blobName, int accessTimeOut = 5) { 

            SharedAccessBlobPolicy defaultAccessPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(accessTimeOut),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
            };

            var blob =this.GetPageContainer(blobName);
            var sasBlobToken = blob.GetSharedAccessSignature(defaultAccessPolicy);      
        }
    }
}
