using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

public static class QueueFactory {
    public static QueueClient Create(string connection, string queueName) => new QueueClient(connection, queueName);
}

public static class TopicFactory {
    
     public static TopicClient Create(string connection, string topicName) => new TopicClient(connection, topicName);

}