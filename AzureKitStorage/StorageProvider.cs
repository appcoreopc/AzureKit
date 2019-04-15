using System;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace AzureKitStorage
{
    public class StorageProvider
    {
        private readonly ICloudBlob storageObject;
                
        public StorageProvider(ICloudBlob account)
        {
            this.storageObject = account;
        }

        public async Task<Uri> UploadFileAsync(string filename)
        {
            await this.storageObject.UploadFromFileAsync(filename);
            return this.storageObject.Uri;
        }

        public async Task<Uri> DownloadAsync(string filename)
        {
            await this.storageObject.DownloadToFileAsync(filename, System.IO.FileMode.OpenOrCreate);
            return this.storageObject.Uri;
        }

        public async Task<bool> DeleteAsync(string filename)
        {
            return await this.storageObject.DeleteIfExistsAsync();
        }

        public string GetAccessUrl(string containerName, string blobName)
        {
            SharedAccessBlobPolicy defaultAccessPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
            };

            var sharedAccess = this.storageObject.GetSharedAccessSignature(defaultAccessPolicy);
            return this.storageObject.Uri.AbsoluteUri + sharedAccess;
        }
    }
}
