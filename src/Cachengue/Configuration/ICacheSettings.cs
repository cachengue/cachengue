using ProviderModel.Configuration;

namespace Cachengue.Configuration
{
    /// <summary>
    /// Defines the contract for the cache settings
    /// </summary>
    public interface ICacheSettings : IProvidersSettings
    {
        /// <summary>
        /// Gets the default absolute expiration minutes.
        /// </summary>
        /// <value>
        /// The default absolute expiration minutes.
        /// </value>
        int DefaultAbsoluteExpirationSeconds { get; }

        /// <summary>
        /// Gets a value indicating whether caching is enabled is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; }

        /// <summary>
        /// Gets the max fail attempts before disabling the cache.
        /// </summary>
        /// <value>
        /// The max fail attempts.
        /// </value>
        int MaxFailAttempts { get; }

        /// <summary>
        /// Gets the max retry attempts at connecting to the cache provider
        /// </summary>
        /// <value>
        /// The max retry attempts.
        /// </value>
        int MaxRetryAttempts { get; }

        /// <summary>
        /// Gets a value indicating whether logging should be verbose or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if logging should be verbose; otherwise, <c>false</c>.
        /// </value>
        bool VerboseLogging { get; }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <value>
        /// The serializer.
        /// </value>
        string Serializer { get; }

        /// <summary>
        /// Gets the statistics.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        CacheStatisticsElement Statistics { get; }

        /// <summary>
        /// Determines whether [is read only].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is read only]; otherwise, <c>false</c>.
        /// </returns>
        bool IsReadOnly();
    }
}
