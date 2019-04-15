using System;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace AzureKitStorage
{
    public class BlobStorageProvider
    {
        private readonly ICloudBlob storageObject;

        private CloudBlobContainer container;

        public BlobStorageProvider(ICloudBlob account)
        {
            this.storageObject = account;
        }

        public async Task<Uri> UploadFileAsync(string containerName, string blobName, string filename)
        {
            await this.storageObject.UploadFromFileAsync(filename);
            return this.storageObject.Uri;
        }

        public async Task<Uri> DownloadAsync(string filename)
        {
            await this.storageObject.DownloadToFileAsync(filename, System.IO.FileMode.OpenOrCreate);
            return this.storageObject.Uri;
        }
    }
}
