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
        string name = req.Query["name"];
        return name != null
            ? new OkObjectResult($"Hello, {name}!")
            : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
    }
}