using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureStorageKit.BlobProvider
{
    public interface IStorageProviderFeature
    {

        Task<Uri> UploadFile(string containerName, string blobName, string filename);

        Task<IList<string>> ListFiles(string containerName, string blobName, string pattern);

        Task<Uri> DonwloadFile(string containerName, string blobName, string filename);

        Task<Uri> DeletedFile(string containerName, string blobName, string filename);

    }
}