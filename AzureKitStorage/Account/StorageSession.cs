using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;

namespace AzureKitStorage.Account
{
    public class StorageSession : IStorageSession {

        public CloudStorageAccount CreateStorageProvider(string connection) { 

                return CloudStorageAccount.Parse(connection);      
        }
    }
}