using System;
using System.Linq;
using System.Runtime.Caching;

namespace Cachengue.Providers.Runtime
{
    /// <summary>
    /// A cache provider that relies on System.Runtime.Caching
    /// </summary>
    public class RuntimeCacheProvider : CacheProviderBase
    {
        /// <summary>
        /// Gets a value indicating whether the cache provider is available.
        /// </summary>
        /// <value>
        /// <c>true</c> if the cache provider is available; otherwise, <c>false</c>.
        /// </value>
        public override bool IsAvailable
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the count of items stored in the cache.
        /// </summary>
        /// <value>
        /// The count of items stored in the cache.
        /// </value>
        public override int Size
        {
            get { return (int)RuntimeCache.GetCount(); }
        }

        /// <summary>
        /// Gets the stored cache keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public override string[] Keys
        {
            get { return RuntimeCache.Select(x => x.Key).ToArray(); }
        }

        private ObjectCache RuntimeCache
        {
            get { return MemoryCache.Default; }
        }

        /// <summary>
        /// Tries to get the value from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the value exists on the cache, otherwise <c>false</c>.
        /// </returns>
        public override bool TryGetValue(string key, Type type, out object value)
        {
            if (!RuntimeCache.Contains(key))
            {
                value = null;
                return false;
            }

            value = RuntimeCache.Get(key);
            return true;
        }

        /// <summary>
        /// Stores the object on the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The object type to store.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        public override void SetValue(string key, Type type, object value, CacheOptions options = null)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddSeconds(options.ExpirationSeconds);
            switch (options.Priority)
            {
                case CacheItemPriority.Default:
                case CacheItemPriority.High:
                case CacheItemPriority.Low:
                case CacheItemPriority.Normal:
                    policy.Priority = System.Runtime.Caching.CacheItemPriority.Default;
                    break;
                case CacheItemPriority.NotRemovable:
                    policy.Priority = System.Runtime.Caching.CacheItemPriority.NotRemovable;
                    break;
            }

            foreach (var runtimeDependency in options.Dependencies.Select(d => d as RuntimeCacheDependency).Where(runtimeDependency => runtimeDependency != null))
            {
                policy.ChangeMonitors.Add(runtimeDependency.ChangeMonitor);
            }

            if (options.UpdateCallback != null)
            {
                policy.UpdateCallback = arguments => options.UpdateCallback(arguments.Key, arguments.UpdatedCacheItem.Value);
            }

            if (options.RemovedCallback != null)
            {
                policy.RemovedCallback = arguments => options.RemovedCallback(arguments.CacheItem.Key, arguments.CacheItem.Value);
            }

            RuntimeCache.Set(key, value, policy);
        }

        /// <summary>
        /// Determines whether the specified key exists on the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key exists; otherwise, <c>false</c>.
        /// </returns>
        public override bool Contains(string key)
        {
            return RuntimeCache.Contains(key);
        }

        /// <summary>
        /// Deletes the specified key from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the key was succesfully removed; otherwise, <c>false</c>.
        /// </returns>
        public override bool Remove(string key)
        {
            if (Contains(key))
            {
                return false;
            }

            RuntimeCache.Remove(key);
            return true;
        }

        /// <summary>
        /// Removes all the keys from the cache.
        /// </summary>
        public override void FlushAll()
        {
            foreach (var key in RuntimeCache.Select(x => x.Key))
            {
                RuntimeCache.Remove(key);
            }
        }
    }
}
