﻿using Asp.Versioning;
using BuildingBlocks.AzureServiceBus;
using BuildingBlocks.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Api
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0); //same as ApiVersion.Default
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                                 new UrlSegmentApiVersionReader(),
                                 new QueryStringApiVersionReader("api-version"),
                                 new HeaderApiVersionReader("X-Version"),
                                 new MediaTypeApiVersionReader("X-Version")
                                 );
            }).AddMvc(options => { })
                                .AddApiExplorer(options =>
                                {
                                    options.GroupNameFormat = "'v'VVV";
                                    options.SubstituteApiVersionInUrl = true;
                                    options.AddApiVersionParametersWhenVersionNeutral = true;
                                }); ;

            services.AddSingleton<IServiceBusClientProvider>(sp =>
                new ServiceBusClientProvider(configuration.GetConnectionString("AzureServiceBus")));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddExceptionHandler<CustomExceptionHandler>();

            return services;
        }
    }
}
