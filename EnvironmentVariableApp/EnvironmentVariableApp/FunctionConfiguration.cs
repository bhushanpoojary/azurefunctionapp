using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EnvironmentVariableApp;

public class FunctionConfiguration
{
    private readonly IConfiguration _config;

    public FunctionConfiguration(IConfiguration config)
    {
        _config = config;
    }

    [Function("FunctionConfiguration")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        string? val = _config["MyCustomSetting"];
        return new OkObjectResult(val);
    }
}