using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;

public interface IStorageSession
{
    CloudStorageAccount CreateStorageProvider(string connection);
}
