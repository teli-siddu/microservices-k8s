using System;

public class ServiceBusClient : IServiceBusClient
{
    private readonly ServiceBusClient _client;

    public ServiceBusClient(string connectionString)
    {
        _client = new ServiceBusClient(connectionString);
    }

    public async Task SendMessageAsync(string queueName, string messageBody)
    {
        var sender = _client.CreateSender(queueName);
        var message = new ServiceBusMessage(messageBody);
        await sender.SendMessageAsync(message);
        await sender.DisposeAsync();
    }

    public async Task ReceiveMessagesAsync(string queueName, Func<string, Task> messageHandler)
    {
        var processor = _client.CreateProcessor(queueName, new ServiceBusProcessorOptions
        {
            AutoCompleteMessages = false
        });

        processor.ProcessMessageAsync += async args =>
        {
            await messageHandler(args.Message.Body.ToString());
            await args.CompleteMessageAsync(args.Message);
        };

        processor.ProcessErrorAsync += args =>
        {
            // Log error
            return Task.CompletedTask;
        };

        await processor.StartProcessingAsync();
    }
}