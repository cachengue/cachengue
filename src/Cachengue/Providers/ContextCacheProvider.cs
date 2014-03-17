using System.Collections;

namespace Cachengue.Providers
{
    /// <summary>
    /// A cache provider for contextual cache providers
    /// </summary>
    public abstract class ContextCacheProvider : MemoryCacheProvider
    {
        private const string CACHE_KEY = "ContextValue:Cache";
        private const string EXPIRATIONS_KEY = "ContextValue:CacheExpirations";

        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <value>
        /// The cache.
        /// </value>
        protected override IDictionary Cache
        {
            get { return GetOrAddFromContext<Hashtable>(CACHE_KEY); }
        }

        /// <summary>
        /// Gets the cache expirations.
        /// </summary>
        /// <value>
        /// The cache expirations.
        /// </value>
        protected override ICacheExpirations CacheExpirations
        {
            get { return GetOrAddFromContext<InMemoryCacheExpirations>(EXPIRATIONS_KEY); }
        }

        /// <summary>
        /// Gets or adds and gets a type from the context
        /// </summary>
        /// <typeparam name="TContextData">The type of the context data.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="constructorArgs">The constructor args.</param>
        /// <returns>
        /// The stored value from the context
        /// </returns>
        protected abstract TContextData GetOrAddFromContext<TContextData>(string key, params object[] constructorArgs) where TContextData : class;
    }
}
