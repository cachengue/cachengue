using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cachengue.DesignByContract;

namespace Cachengue.Providers
{
    /// <summary>
    /// A in memory fast cache provider.
    /// </summary>
    public class MemoryCacheProvider : CacheProviderBase
    {
        private readonly Dictionary<string, object> _cache = new Dictionary<string, object>();
        private readonly ICacheExpirations _expirations = new InMemoryCacheExpirations();

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
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public override int Size
        {
            get { return Cache.Count; }
        }

        /// <summary>
        /// Gets the stored cache keys
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public override string[] Keys
        {
            get { return Cache.Keys.Cast<string>().ToArray(); }
        }

        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <value>
        /// The cache.
        /// </value>
        protected virtual IDictionary Cache
        {
            get { return _cache; }
        }

        /// <summary>
        /// Gets the cache expirations.
        /// </summary>
        /// <value>
        /// The cache expirations.
        /// </value>
        protected virtual ICacheExpirations CacheExpirations
        {
            get { return _expirations; }
        }

        /// <summary>
        /// Tries to get the value from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <c>true</c> if the value exists on the cache, otherwise <c>false</c>.
        /// </returns>
        public override bool TryGetValue(string key, Type type, out object value)
        {
            Check.Require<ArgumentNullException>(!string.IsNullOrWhiteSpace(key), "The key is required");
            Check.Require<ArgumentNullException>(type != null, "The type is required");

            if (Contains(key))
            {
                value = Cache[key];
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Stores the object on the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The object type to store.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        public override void SetValue(string key, Type type, object value, CacheOptions options)
        {
            Check.Require<ArgumentNullException>(!string.IsNullOrWhiteSpace(key), "The key is required");
            Check.Require<ArgumentNullException>(type != null, "The type is required");
            Check.Require<ArgumentNullException>(options != null, "Cache options absolute expiration is required");

            Cache[key] = value;
            CacheExpirations.SetExpiration(key, options.ExpirationSeconds);
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
            Check.Require<ArgumentNullException>(!string.IsNullOrWhiteSpace(key), "The key is required");

            CheckExpiration(key);

            return Cache.Contains(key);
        }

        /// <summary>
        /// Deletes the specified key from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     <c>true</c> if the key was succesfully removed; otherwise, <c>false</c>.
        /// </returns>
        public override bool Remove(string key)
        {
            Check.Require<ArgumentNullException>(!string.IsNullOrWhiteSpace(key), "The key is required");

            CheckExpiration(key);

            if (!Cache.Contains(key))
            {
                return false;
            }

            Cache.Remove(key);
            return true;
        }

        /// <summary>
        /// Removes all the keys from the cache.
        /// </summary>
        public override void FlushAll()
        {
            Cache.Clear();
            CacheExpirations.Clear();
        }

        private void CheckExpiration(string key)
        {
            if (CacheExpirations.KeyHasExpired(key))
            {
                Cache.Remove(key);
            }
        }
    }
}
