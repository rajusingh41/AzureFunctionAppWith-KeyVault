using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace functionApp
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly ApiConfig _config;

        public Function1(ILoggerFactory loggerFactory, ApiConfig config)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _config = config;
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var reqUrl = _config.EndpointUrl;
            _logger.LogInformation("Hi {ReqUrl}", reqUrl);
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
