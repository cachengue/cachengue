using System;

namespace Cachengue.Providers
{
    /// <summary>
    /// A no store cache provider
    /// </summary>
    public sealed class NullCacheProvider : CacheProviderBase
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
        /// Gets the stored cache keys
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public override string[] Keys
        {
            get { return new string[] { }; }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public override int Size
        {
            get { return 0; }
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
        public override void SetValue(string key, System.Type type, object value, CacheOptions options = null)
        {
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
            return false;
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
            return true;
        }

        /// <summary>
        /// Removes all the keys from the cache.
        /// </summary>
        public override void FlushAll()
        {
        }
    }
}
