using System;

namespace Scoring.Logger
{
    public interface ILogger
    {
        void LogInformation(string message);

        void LogInformation(string message, Exception ex);

        void LogAdvertencia(string message);

        void LogAdvertencia(string message, Exception ex);

        void LogError(string message);

        void LogError(string message, Exception ex);

        void LogDebug(string message);
    }
}
