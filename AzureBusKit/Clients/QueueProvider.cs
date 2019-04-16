using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureBusKit
{
    public class QueueProvider
    {
        private readonly QueueClient client;
        public QueueProvider(QueueClient client)
        {
            this.client = client;
        }

        public void ConfigureMessageHandler(Func<Message, CancellationToken, Task> messageHandler, Func<ExceptionReceivedEventArgs, Task>  exceptionHandler) {
            this.client.RegisterMessageHandler(messageHandler, exceptionHandler);
        }

        public async Task SendMessageAsync(Message message) 
        {
            await this.client.SendAsync(message);
        }

        public async Task SendMessagesAsync(IList<Message> messages) 
        {
            await this.client.SendAsync(messages);
        }
    }
}
