using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Nh.HelloWorld
{
    public class ChTestApp
    {
        private readonly ITestService _testService;
        private readonly ILogger<ChTestApp> _logger;
        private readonly ChAppSettings _config;

        public ChTestApp(ITestService testService, IOptions<ChAppSettings> config, ILogger<ChTestApp> logger)
        {
            _testService = testService;
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Subject}");
            _testService.Run();
            Console.ReadKey();
        }
    }

    public class ChAppSettings
    {
        public string Subject { get; set; }
    }
}
