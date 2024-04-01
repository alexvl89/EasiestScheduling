using Coravel.Invocable;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestScheduling;

internal class MyRepeatableTask : IInvocable
{
    private readonly ILogger<MyRepeatableTask> _logger;

    private readonly string _connectionString;

    public MyRepeatableTask(ILogger<MyRepeatableTask> logger, string connectionString)
    {
        _logger = logger;
        _connectionString = connectionString;
    }

    public async Task Invoke()
    {
        _logger.LogInformation("Hello from invocable, with {String}", _connectionString);
    }
}
