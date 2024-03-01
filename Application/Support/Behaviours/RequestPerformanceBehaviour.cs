using Application.Support.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Support.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _timer = new Stopwatch();
            _logger = logger;
            _currentUserService = currentUserService;
        }
        // A pipeline behavior is an implementation of IPipelineBehavior<TRequest, TResponse>. 
        //It represents a similar pattern to filters in ASP.NET MVC/Web API or pipeline behaviors in NServiceBus. Your pipeline behavior needs to implement one method:
        //Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
        //he request parameter is the request object passed in through IMediator.Send, while the next parameter is an async continuation for the next action in the behavior chain.
        //In your behavior, you'll need to await or return the invocation of the next delegate. 
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                _logger.LogWarning("Northwind Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                    name, _timer.ElapsedMilliseconds, _currentUserService.UserId, request);
            }

            return response;
        }
    }
}
