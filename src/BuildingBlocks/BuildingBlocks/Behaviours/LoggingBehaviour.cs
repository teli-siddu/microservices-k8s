﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle request={Request} - Response={Response} - RequestData={RequestData}",
              typeof(TRequest).Name, typeof(TResponse), request);
            var timer = new Stopwatch();

            timer.Start();

            var response = await next();

            timer.Stop();

            var timeTaken = timer.Elapsed;
            if (timeTaken.Seconds > 3)
            {
                logger.LogWarning("[PERFORMANACE] The request {Request} took {TimeElapsed} seconds", typeof(TRequest), timeTaken.Seconds);
            }
            logger.LogInformation("[END] handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse));

            return response;
        }
    }
}
