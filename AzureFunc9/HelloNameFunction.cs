using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunc9;

public class HelloNameFunction
{
    private readonly ILogger<HelloNameFunction> _logger;

    public HelloNameFunction(ILogger<HelloNameFunction> logger)
    {
        _logger = logger;
    }

    [Function("HelloNameFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!!!");
    }
}