using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.AzureServiceBus
{
    public interface IServiceBusClientProvider
    {
        Task SendMessageAsync(string queueOrTopicName, string messageBody, bool isTopic = true);
        Task<ServiceBusReceivedMessage> ReceiveMessageAsync(string queueOrTopicName, string subscriptionName = null, bool isTopic = true);
        Task CompleteMessageAsync(string queueOrTopicName, ServiceBusReceivedMessage message, string subscriptionName = null, bool isTopic = true);
    }
}
