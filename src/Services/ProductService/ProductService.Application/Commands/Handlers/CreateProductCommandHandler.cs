using AutoMapper;
using BuildingBlocks.AzureServiceBus;
using MediatR;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Models;
using System.Text.Json;

namespace ProductService.Application.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IServiceBusClientProvider _serviceBusClient;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IServiceBusClientProvider serviceBusClient)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _serviceBusClient = serviceBusClient;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request.ProductDto);
            var result=await _productRepository.CreateProductAsync(productEntity);
            await _serviceBusClient.SendMessageAsync("dev-employees", JsonSerializer.Serialize(productEntity), false);
            return result;
          
        }
    }
}
