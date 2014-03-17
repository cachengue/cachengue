using System;
using System.Configuration;

namespace Cachengue.Configuration
{
    /// <summary>
    /// A default cache settings to be used when no configuration is set
    /// </summary>
    [Serializable]
    internal class DefaultSettings : ICacheSettings
    {
        /// <summary>
        /// A singleton for the settings
        /// </summary>
        public static DefaultSettings Instance = new DefaultSettings();

        private readonly ProviderSettingsCollection _emptyProviders = new ProviderSettingsCollection();
        private readonly CacheStatisticsElement _disabledStatistics = new CacheStatisticsElement();

        private DefaultSettings()
        {
        }

        /// <summary>
        /// Gets the default absolute expiration minutes.
        /// </summary>
        /// <value>
        /// The default absolute expiration minutes.
        /// </value>
        public int DefaultAbsoluteExpirationSeconds
        {
            get { return 1800; }
        }

        /// <summary>
        /// Gets a value indicating whether caching is enabled is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the max fail attempts before disabling the cache.
        /// </summary>
        /// <value>
        /// The max fail attempts.
        /// </value>
        public int MaxFailAttempts
        {
            get { return 10; }
        }

        /// <summary>
        /// Gets the max retry attempts at connecting to the cache provider
        /// </summary>
        /// <value>
        /// The max retry attempts.
        /// </value>
        public int MaxRetryAttempts
        {
            get { return 100; }
        }

        /// <summary>
        /// Gets a value indicating whether [enable logging].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable logging]; otherwise, <c>false</c>.
        /// </value>
        public bool VerboseLogging
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <value>
        /// The serializer.
        /// </value>
        public string Serializer
        {
            get { return "json"; }
        }

        /// <summary>
        /// Gets the default provider.
        /// </summary>
        /// <value>
        /// The default provider.
        /// </value>
        public string DefaultProvider
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the statistics.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public CacheStatisticsElement Statistics
        {
            get { return _disabledStatistics; }
        }

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>
        /// The providers.
        /// </value>
        public ProviderSettingsCollection Providers
        {
            get { return _emptyProviders; }
        }

        /// <summary>
        /// Determines whether [is read only].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is read only]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsReadOnly()
        {
            return false;
        }
    }
}
