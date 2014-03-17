using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using ProviderModel.Configuration;

namespace Cachengue.Configuration
{
    /// <summary>
    /// Caching configuration section handler
    /// </summary>
    public class CachingSectionHandler : ProviderSectionHandler, ICacheSettings
    {
        /// <summary>
        /// The name of the caching section
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NAME", Justification = "Supported by conventions")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Supported by conventions")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SECTION", Justification = "Supported by conventions")]
        public const string SECTION_NAME = "cinchcast.framework.caching";

        private static CachingSectionHandler _section;

        /// <summary>
        /// Gets the default absolute expiration minutes.
        /// </summary>
        /// <value>
        /// The default absolute expiration minutes.
        /// </value>
        [ConfigurationProperty("defaultAbsoluteExpirationSeconds", DefaultValue = 1800)]
        public int DefaultAbsoluteExpirationSeconds
        {
            get { return (int)base["defaultAbsoluteExpirationSeconds"]; }
        }

        /// <summary>
        /// Gets a value indicating whether caching is enabled is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool Enabled
        {
            get { return (bool)base["enabled"]; }
        }

        /// <summary>
        /// Gets the max fail attempts before disabling the cache.
        /// </summary>
        /// <value>
        /// The max fail attempts.
        /// </value>
        [ConfigurationProperty("maxFailAttempts", DefaultValue = 10)]
        public int MaxFailAttempts
        {
            get { return (int)base["maxFailAttempts"]; }
        }

        /// <summary>
        /// Gets the max retry attempts at connecting to the cache provider
        /// </summary>
        /// <value>
        /// The max retry attempts.
        /// </value>
        [ConfigurationProperty("maxRetryAttempts", DefaultValue = 100)]
        public int MaxRetryAttempts
        {
            get { return (int)base["maxRetryAttempts"]; }
        }

        /// <summary>
        /// Gets a value indicating whether [enable logging].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable logging]; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("verboseLogging", DefaultValue = false)]
        public bool VerboseLogging
        {
            get { return (bool)base["verboseLogging"]; }
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <value>
        /// The serializer.
        /// </value>
        [ConfigurationProperty("serializer", DefaultValue = "json")]
        public string Serializer
        {
            get { return (string)base["serializer"]; }
        }

        /// <summary>
        /// Gets the statistics.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        [ConfigurationProperty("statistics")]
        public CacheStatisticsElement Statistics
        {
            get { return (CacheStatisticsElement)base["statistics"]; }
        }

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        internal static CachingSectionHandler Section
        {
            get
            {
                if (_section == null)
                {
                    _section = ConfigurationManager.GetSection(SECTION_NAME) as CachingSectionHandler;
                }

                return _section;
            }
        }
    }
}
