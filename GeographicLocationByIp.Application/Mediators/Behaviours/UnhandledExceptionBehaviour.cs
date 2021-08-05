using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GeographicLocationByIp.Application.Mediators.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }

        private readonly ILogger<TRequest> logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof( TRequest ).Name;
                var stackTrace = Environment.StackTrace;
                logger.LogError(ex, "Unhandled Exception for Request. StackTrace: {@stackTrace}", stackTrace, requestName, request);

                throw;
            }
        }
    }
}