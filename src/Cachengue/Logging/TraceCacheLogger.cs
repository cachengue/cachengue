using System;
using System.Diagnostics;

namespace Cachengue.Logging
{
    /// <summary>
    /// A System.Diagnostics.Trace Cache Logger
    /// </summary>
    public class TraceCacheLogger: ICacheLogger
    {
        /// <summary>
        /// Returns a singleton instance of the TraceCacheLogger
        /// </summary>
        public static readonly TraceCacheLogger Instance = new TraceCacheLogger();

        private TraceCacheLogger()
        {
        }

        /// <summary>
        /// Logs when a cache key is found.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        /// <param name="operationTimeMs">The operation time in ms.</param>
        public void LogCacheHit(string message, CacheExecutionInformation executionInformation, long operationTimeMs)
        {
            Trace.TraceInformation(string.Format(@"Message: {0}{1}Duration:{2}{1}{3}", message, operationTimeMs, Environment.NewLine, executionInformation));
        }

        /// <summary>
        /// Logs when a cache key is not found.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        /// <param name="operationTimeMs">The operation time in ms.</param>
        public void LogCacheMiss(string message, CacheExecutionInformation executionInformation, long operationTimeMs)
        {
            Trace.TraceInformation(string.Format(@"Message: {0}{1}Duration:{2}{1}{3}", message, operationTimeMs, Environment.NewLine, executionInformation));
        }

        /// <summary>
        /// Logs information.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        public void LogInformation(string message, CacheExecutionInformation executionInformation)
        {
            Trace.TraceInformation(string.Format(@"Message: {0}{1}{2}", message, Environment.NewLine, executionInformation));
        }

        /// <summary>
        /// Logs when an exception is thrown.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        /// <param name="exception">The exception.</param>
        public void LogException(string message, CacheExecutionInformation executionInformation, Exception exception)
        {
            Trace.TraceError(string.Format(@"Message: {0}{1}Exception:{2}{1}{3}", message, exception.ToErrorMessage(), Environment.NewLine, executionInformation));
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        public void LogWarning(string message, CacheExecutionInformation executionInformation)
        {
            Trace.TraceWarning(string.Format(@"Message: {0}{1}{2}", message, Environment.NewLine, executionInformation));
        }
    }
}
