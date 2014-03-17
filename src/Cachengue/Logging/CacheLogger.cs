namespace Cachengue.Logging
{
    /// <summary>
    /// The configured cache logger
    /// </summary>
    public static class CacheLogger
    {
        private static ICacheLogger _cacheLogger;

        /// <summary>
        /// Gets or sets the cache logger.
        /// </summary>
        /// <value>
        /// The cache logger.
        /// </value>
        public static ICacheLogger Current
        {
            get
            {
                if (_cacheLogger == null)
                {
                    try
                    {
                        _cacheLogger = CachengueDependencyResolver.GetService<ICacheLogger>();
                    }
                    catch
                    {
                        _cacheLogger = TraceCacheLogger.Instance;
                    }
                }

                return _cacheLogger;
            }

            set
            {
                _cacheLogger = value;
            }
        }
    }
}
