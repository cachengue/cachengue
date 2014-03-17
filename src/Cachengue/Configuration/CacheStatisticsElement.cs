using System.Configuration;

namespace Cachengue.Configuration
{
    /// <summary>
    /// The statistics configuration element
    /// </summary>
    public class CacheStatisticsElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CacheStatisticsElement"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("enabled", IsRequired = true, DefaultValue = false)]
        public bool Enabled
        {
            get { return (bool)base["enabled"]; }
            set { base["enabled"] = value; }
        }

        /// <summary>
        /// Gets or sets the typeName of the provider.
        /// </summary>
        /// <value>
        /// The typeName.
        /// </value>
        /// <remarks>This property is required</remarks>
        [ConfigurationProperty("storageType", IsRequired = true)]
        public string StorageTypeName
        {
            get { return (string)base["storageType"]; }
            set { base["storageType"] = value; }
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        [ConfigurationProperty("settings", IsRequired = false)]
        public NameValueConfigurationCollection Settings
        {
            get { return (NameValueConfigurationCollection)base["settings"]; }
        }
    }
}
