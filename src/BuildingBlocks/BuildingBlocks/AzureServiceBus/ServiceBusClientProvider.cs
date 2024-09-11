using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.AzureServiceBus
{
    public class ServiceBusClientProvider : IServiceBusClientProvider, IDisposable
    {
        private readonly ServiceBusClient _serviceBusClient;

        public ServiceBusClientProvider(string connectionString)
        {
            _serviceBusClient = new ServiceBusClient(connectionString);
        }

        // Send a message to a queue or a topic
        public async Task SendMessageAsync(string queueOrTopicName, string messageBody, bool isTopic = true)
        {
            ServiceBusSender sender = isTopic
                ? _serviceBusClient.CreateSender(queueOrTopicName) // topic
                : _serviceBusClient.CreateSender(queueOrTopicName); // queue

            ServiceBusMessage message = new ServiceBusMessage(messageBody);

            try
            {
                await sender.SendMessageAsync(message);
            }
            finally
            {
                await sender.DisposeAsync();
            }
        }

        // Receive a message from a queue or a topic's subscription
        public async Task<ServiceBusReceivedMessage> ReceiveMessageAsync(string queueOrTopicName, string subscriptionName = null, bool isTopic = true)
        {
            ServiceBusReceiver receiver = isTopic
                ? _serviceBusClient.CreateReceiver(queueOrTopicName, subscriptionName) // topic subscription
                : _serviceBusClient.CreateReceiver(queueOrTopicName); // queue

            try
            {
                return await receiver.ReceiveMessageAsync();
            }
            finally
            {
                await receiver.DisposeAsync();
            }
        }

        // Complete a message after processing
        public async Task CompleteMessageAsync(string entityName, ServiceBusReceivedMessage message, string subscriptionName = null, bool isTopic = true)
        {
            ServiceBusReceiver receiver = isTopic
                ? _serviceBusClient.CreateReceiver(entityName, subscriptionName) // topic subscription
                : _serviceBusClient.CreateReceiver(entityName); // queue

            try
            {
                await receiver.CompleteMessageAsync(message);
            }
            finally
            {
                await receiver.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _serviceBusClient.DisposeAsync().AsTask().Wait();
        }
    }
}
