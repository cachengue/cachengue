namespace Cachengue
{
    /// <summary>
    /// Defines the contract for the class that will use the CacheAttribute to pick a cache provider depending
    /// on specific business logic performed by the class itself.
    /// </summary>
    public interface ICacheProviderSelector
    {
        /// <summary>
        /// Gets the cache provider name.
        /// </summary>
        /// <returns>The cache provider name</returns>
        string GetCacheProvider();
    }
}
