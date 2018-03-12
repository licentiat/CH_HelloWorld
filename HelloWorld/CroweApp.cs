using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nh.HelloWorld
{
    public class CroweApp
    {
        private readonly ITestService _testService;
        private readonly ILogger<CroweApp> _logger;
        private readonly CroweAppSettings _config;

        public CroweApp(ITestService testService, IOptions<CroweAppSettings> config, ILogger<CroweApp> logger)
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

    public class CroweAppSettings
    {
        public string Subject { get; set; }
    }
}
