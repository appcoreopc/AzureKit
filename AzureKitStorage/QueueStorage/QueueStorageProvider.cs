
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;

public class QueueStorageProvider 
{ 
    private readonly CloudQueue cloudQueue;
    public QueueStorageProvider(CloudQueue cloudQueue)
    {
        this.cloudQueue = cloudQueue;
    }

    public async Task SendMessageAsync(CloudQueueMessage message) => await this.cloudQueue.AddMessageAsync(message);

    public async Task<CloudQueueMessage> PeekMessage() => await this.cloudQueue.PeekMessageAsync();

    public async Task<CloudQueueMessage> GetMessage() => await this.cloudQueue.GetMessageAsync();

    public async Task<IEnumerable<CloudQueueMessage>> GetMessages(int count) => await this.cloudQueue.GetMessagesAsync(count);

}