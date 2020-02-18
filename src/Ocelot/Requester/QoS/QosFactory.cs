using Ocelot.Configuration;
using Ocelot.Logging;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Responses;
using System;
using System.Net.Http;

namespace Ocelot.Requester.QoS
{
    public class QoSFactory : IQoSFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOcelotLoggerFactory _ocelotLoggerFactory;

        public QoSFactory(IServiceProvider serviceProvider, IOcelotLoggerFactory ocelotLoggerFactory)
        {
            _serviceProvider = serviceProvider;
            _ocelotLoggerFactory = ocelotLoggerFactory;
        }

        public Response<DelegatingHandler> Get(DownstreamReRoute request)
        {
            var handler = _serviceProvider.GetService<QosDelegatingHandlerDelegate>();

            if (handler != null)
            {
                return new OkResponse<DelegatingHandler>(handler(request, _ocelotLoggerFactory));
            }

            return new ErrorResponse<DelegatingHandler>(new UnableToFindQoSProviderError($"could not find qosProvider for {request.DownstreamScheme}{request.DownstreamAddresses}{request.DownstreamPathTemplate}"));
        }
    }
}
