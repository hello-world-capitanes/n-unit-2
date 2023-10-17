
using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;

namespace Scoring.Logger
{
    public class LoggerImpl : ILogger
    {
        private readonly ILog _logger;
        private static ILoggerRepository loggerRepository = null;

        public LoggerImpl()
        {
            if(LoggerImpl.loggerRepository == null)
            {
                LoggerImpl.loggerRepository = LogManager.CreateRepository("ApiScoringRentACar");
            }
            XmlConfigurator.Configure(loggerRepository, new FileInfo("log4net.config"));
            _logger = LogManager.GetLogger(loggerRepository.Name, typeof(LoggerImpl));
        }

        public void LogAdvertencia(string message)
        {
            _logger.Warn(message);
        }

        public void LogAdvertencia(string message, Exception ex)
        {
            _logger.Warn(message, ex);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(message, ex);
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
        }

        public void LogInformation(string message, Exception ex)
        {
            _logger.Info(message, ex);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

    }
}
