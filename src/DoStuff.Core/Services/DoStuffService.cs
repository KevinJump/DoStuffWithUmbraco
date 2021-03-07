// DoStuffWithUnicore - Examples of Umbraco code for .net core
//
// File: DoStuffService Class 
//
// Note: Demonstrates a Service class, that uses:
//       - Dependency Injection
//       - Logging
//       - Configuration


using DoStuff.Core.Configuration;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DoStuff.Core.Services
{
    public class DoStuffService
    {
        private readonly ILogger<DoStuffService> _logger;
        private readonly DoStuffOptions _options;

        public DoStuffService(ILoggerFactory loggerFactory, IOptions<DoStuffOptions> options)
        {
            _logger = loggerFactory.CreateLogger<DoStuffService>();
            _options = options.Value;
        }

        public bool IsHigherThanMagicNumber(int number)
        {
            _logger.LogDebug("Checking if {number} is higher than {magic}", number, _options.MagicNumber);
            return number > _options.MagicNumber;
        }
    }
}
