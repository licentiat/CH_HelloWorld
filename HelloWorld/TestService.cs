using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Nh.HelloWorld
{
    public interface ITestService
    {
        void Run();
    }

    class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;
        private readonly CroweAppSettings _config;

        public TestService(ILogger<TestService> logger, IOptions<CroweAppSettings> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogWarning($"Hello world!... from test service of: {_config.Subject}");
        }
    }
}
