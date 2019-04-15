using AzureKitStorage;
using AzureKitStorage.Account;
using Xunit;

namespace AzureStorageKit.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var target = StorageSession.CreateStorageProvider("").CreateBlobAsync("").Result.CreatePageStorage("");
            var storageProvider = new StorageProvider(target);
        }
    }
}
