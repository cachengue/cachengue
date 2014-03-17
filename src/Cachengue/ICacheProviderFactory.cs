using System.Collections.Generic;

namespace Cachengue
{
    public interface ICacheProviderFactory
    {
        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The cache provider by its name</returns>
        CacheProviderBase GetProvider(string name);
        
        /// <summary>
        /// Gets the default provider.
        /// </summary>
        /// <returns>The default cache provider</returns>
        CacheProviderBase GetDefaultProvider();

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <returns>All the cache providers</returns>
        IList<CacheProviderBase> GetProviders();
    }
}
