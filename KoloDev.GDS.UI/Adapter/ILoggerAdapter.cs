namespace KoloDev.GDS.UI.Adapter
{
    /// <summary>
    /// Logging adapter interface
    /// </summary>
    public interface ILoggerAdapter<T>
    {
        #region Information logging

        /// <summary>
        /// Interface to log information with message
        /// </summary>
        /// <param name="message"></param>
        void LogInformation(string message);

        /// <summary>
        /// Interface to log information with 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>

        void LogInformation<T0>(string message, T0 arg0);

        /// <summary>
        /// Interface to log information with 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1);

        /// <summary>
        /// Interface to log information with 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        #endregion Information logging

        #region Error logging

        /// <summary>
        /// Interface to log error with message
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);

        /// <summary>
        /// Interface to log error with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        void LogError<T0>(string message, T0 arg0);

        /// <summary>
        /// Interface to log error with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        void LogError<T0, T1>(string message, T0 arg0, T1 arg1);

        /// <summary>
        /// Interface to log error with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        void LogError<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        #endregion Error logging

        #region Debug logging

        /// <summary>
        /// Interface to log debug with message
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);

        /// <summary>
        /// Interface to log debug with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        void LogDebug<T0>(string message, T0 arg0);

        /// <summary>
        /// Interface to log debug with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        void LogDebug<T0, T1>(string message, T0 arg0, T1 arg1);

        /// <summary>
        /// Interface to log debug with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        void LogDebug<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        #endregion Debug logging

        #region Critical logging

        /// <summary>
        /// Interface to log critical with message
        /// </summary>
        /// <param name="message"></param>
        void LogCritical(string message);

        /// <summary>
        /// Interface to log critical with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        void LogCritical<T0>(string message, T0 arg0);

        /// <summary>
        /// Interface to log critical with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        void LogCritical<T0, T1>(string message, T0 arg0, T1 arg1);

        /// <summary>
        /// Interface to log critical with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        void LogCritical<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        #endregion Critical logging

        #region Warning logging

        /// <summary>
        /// Interface to log warning with message
        /// </summary>
        /// <param name="message"></param>
        void LogWarning(string message);

        /// <summary>
        /// Interface to log warning with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        void LogWarning<T0>(string message, T0 arg0);

        /// <summary>
        /// Interface to log warning with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        void LogWarning<T0, T1>(string message, T0 arg0, T1 arg1);

        /// <summary>
        /// Interface to log warning with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        void LogWarning<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        #endregion Warning logging

        #region Trace logging

        /// <summary>
        /// Interface to log trace with message
        /// </summary>
        /// <param name="message"></param>
        void LogTrace(string message);

        /// <summary>
        /// Interface to log trace with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        void LogTrace<T0>(string message, T0 arg0);

        /// <summary>
        /// Interface to log trace with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        void LogTrace<T0, T1>(string message, T0 arg0, T1 arg1);

        /// <summary>
        /// Interface to log trace with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        void LogTrace<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        #endregion Trace logging
    }

    /// <summary>
    /// Logging adapter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="logger"></param>
        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }

        #region Information logging

        /// <summary>
        /// Log information with message
        /// </summary>
        /// <param name="message"></param>
        public void LogInformation(string message)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message);
            }
        }

        /// <summary>
        /// Log information with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        public void LogInformation<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0);
            }
        }

        /// <summary>
        /// Log information with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0, arg1);
            }
        }

        /// <summary>
        /// Log information with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0, arg1, arg2);
            }
        }

        #endregion Information logging

        #region Error logging

        /// <summary>
        /// Log error with message
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(message);
            }
        }

        /// <summary>
        /// Log error with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        public void LogError<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(message, arg0);
            }
        }

        /// <summary>
        /// Log error with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public void LogError<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(message, arg0, arg1);
            }
        }

        /// <summary>
        /// Log error with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void LogError<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(message, arg0, arg1, arg2);
            }
        }

        #endregion Error logging

        #region Debug logging

        /// <summary>
        /// Log debug with message
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogError(message);
            }
        }

        /// <summary>
        /// Log debug with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        public void LogDebug<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogError(message, arg0);
            }
        }

        /// <summary>
        /// Log debug with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public void LogDebug<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogError(message, arg0, arg1);
            }
        }

        /// <summary>
        /// Log debug with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void LogDebug<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogError(message, arg0, arg1, arg2);
            }
        }

        #endregion Debug logging

        #region Critical logging

        /// <summary>
        /// Log critical with message
        /// </summary>
        /// <param name="message"></param>
        public void LogCritical(string message)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(message);
            }
        }

        /// <summary>
        /// Log critical with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        public void LogCritical<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(message, arg0);
            }
        }

        /// <summary>
        /// Log critical with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public void LogCritical<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(message, arg0, arg1);
            }
        }

        /// <summary>
        /// Log critical with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void LogCritical<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(message, arg0, arg1, arg2);
            }
        }

        #endregion Critical logging

        #region Warning logging

        /// <summary>
        /// Log warning with message
        /// </summary>
        /// <param name="message"></param>
        public void LogWarning(string message)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(message);
            }
        }

        /// <summary>
        /// Log warning with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        public void LogWarning<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(message, arg0);
            }
        }

        /// <summary>
        /// Log warning with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public void LogWarning<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(message, arg0, arg1);
            }
        }

        /// <summary>
        /// Log warning with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void LogWarning<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(message, arg0, arg1, arg2);
            }
        }

        #endregion Warning logging

        #region Trace logging

        /// <summary>
        /// Log trace with message
        /// </summary>
        /// <param name="message"></param>
        public void LogTrace(string message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(message);
            }
        }

        /// <summary>
        /// Log trace with message and 1 parameter
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        public void LogTrace<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(message, arg0);
            }
        }

        /// <summary>
        /// Log trace with message and 2 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public void LogTrace<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(message, arg0, arg1);
            }
        }

        /// <summary>
        /// Log trace with message and 3 parameters
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="message"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void LogTrace<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(message, arg0, arg1, arg2);
            }
        }

        #endregion Trace logging
    }
}