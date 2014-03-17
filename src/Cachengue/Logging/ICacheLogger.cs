using System;

namespace Cachengue.Logging
{
    /// <summary>
    /// Defines the contract for the logging infrastructure for caching
    /// </summary>
    public interface ICacheLogger
    {
        /// <summary>
        /// Logs when a cache key is found.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        /// <param name="operationTimeMs">The operation time in ms.</param>
        void LogCacheHit(string message, CacheExecutionInformation executionInformation, long operationTimeMs);

        /// <summary>
        /// Logs when a cache key is not found.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        /// <param name="operationTimeMs">The operation time ms.</param>
        void LogCacheMiss(string message, CacheExecutionInformation executionInformation, long operationTimeMs);

        /// <summary>
        /// Logs information.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        void LogInformation(string message, CacheExecutionInformation executionInformation);

        /// <summary>
        /// Logs a warning.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        void LogWarning(string message, CacheExecutionInformation executionInformation);

        /// <summary>
        /// Logs when an exception is thrown.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="executionInformation">The execution information.</param>
        /// <param name="exception">The exception.</param>
        void LogException(string message, CacheExecutionInformation executionInformation, Exception exception);
    }
}
