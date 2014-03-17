using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace Cachengue.Providers.Memcached
{
    public class MemcachedCacheProvider : CacheProviderBase
    {
        private MemcachedClient _cache;
        private IMemcachedClientConfiguration _configuration;

        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// The sectionName attribute with the memcached configuration is missing
        /// or
        /// The configuration section  + sectionName +  is missing
        /// </exception>
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            string sectionName = config["sectionName"];

            if (string.IsNullOrWhiteSpace(sectionName))
            {
                throw new ConfigurationErrorsException("The sectionName attribute with the memcached configuration is missing");
            }

            var section = ConfigurationManager.GetSection(sectionName);

            if (section == null)
            {
                throw new ConfigurationErrorsException("The configuration section " + sectionName + " is missing");
            }

            _configuration = section as MemcachedClientSection;

            _cache = new MemcachedClient(_configuration);
        }

        /// <summary>
        /// Gets a value indicating whether the cache provider is available.
        /// </summary>
        /// <value>
        /// <c>true</c> if the cache provider is available; otherwise, <c>false</c>.
        /// </value>
        public override bool IsAvailable
        {
            get
            {
                try
                {
                    _cache.Stats();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        /// <summary>
        /// Gets the count of items stored in the cache (adding all the items from the different servers).
        /// </summary>
        /// <value>
        /// The count of items stored in the cache.
        /// </value>
        public override int Size
        {
            get
            {
                var stats = _cache.Stats();

                return _configuration.Servers.Sum(server => int.Parse(stats.GetRaw(server, StatItem.ItemCount)));
            }
        }

        /// <summary>
        /// Memcached does not support listing all the stored keys
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        /// <exception cref="System.NotSupportedException"></exception>
        public override string[] Keys
        {
            get
            {
                throw new NotSupportedException();
            }
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
            return _cache.TryGet(key, out value);
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
            if (options == null)
            {
                _cache.Store(StoreMode.Set, key, value);
            }
            else
            {
                _cache.Store(StoreMode.Set, key, value, TimeSpan.FromSeconds(options.ExpirationSeconds));
            }
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
            return _cache.Get(key) != null;
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
            return _cache.Remove(key);
        }

        /// <summary>
        /// Removes all the keys from the cache.
        /// </summary>
        public override void FlushAll()
        {
            _cache.FlushAll();
        }
    }
}
