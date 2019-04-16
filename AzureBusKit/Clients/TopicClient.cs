using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

public class TopicProvider { 
    private readonly TopicClient client;
    private readonly ISubscriptionClient subscriptionClient;

    public TopicProvider(TopicClient client, ISubscriptionClient subscriptionClient)
    { 
        this.client = client;
        this.subscriptionClient = subscriptionClient;
    }

    public async Task SendMessageAsync(Message message) 
    {
        await this.client.SendAsync(message);  
    }

    public async Task SendMessageAsync(IList<Message> message) 
    {
        await this.client.SendAsync(message);  
    }
   
    public void ConfigureMessageHandler(Func<Message, CancellationToken, Task> messageHandler, Func<ExceptionReceivedEventArgs, Task>  exceptionHandler) {
            this.subscriptionClient.RegisterMessageHandler(messageHandler, exceptionHandler);
    }
}