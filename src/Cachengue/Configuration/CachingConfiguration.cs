namespace Cachengue.Configuration
{
    /// <summary>
    /// Global class for storing the cache configuration
    /// </summary>
    public static class CachingConfiguration
    {
        private static ICacheSettings _current = CachingSectionHandler.Section as ICacheSettings ?? DefaultSettings.Instance;

        /// <summary>
        /// Gets or sets the current configuration.
        /// </summary>
        /// <value>
        /// The current configuration.
        /// </value>
        public static ICacheSettings Current
        {
            get
            {
                if (_current == null)
                {
                    _current = DefaultSettings.Instance;
                }

                return _current;
            }

            set
            {
                _current = value;
            }
        }

        /// <summary>
        /// Sets from configuration file.
        /// </summary>
        public static void SetFromConfigurationFile()
        {
            _current = CachingSectionHandler.Section;
        }
    }
}
