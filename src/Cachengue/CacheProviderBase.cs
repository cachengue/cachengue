using System;
using System.Configuration.Provider;

namespace Cachengue
{
    /// <summary>
    /// Defines the contract for a cache store
    /// </summary>
    public abstract class CacheProviderBase: ProviderBase
    {
        /// <summary>
        /// Gets a value indicating whether the cache provider is available.
        /// </summary>
        /// <value>
        /// <c>true</c> if the cache provider is available; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsAvailable { get; }

        /// <summary>
        /// Gets the count of items stored in the cache.
        /// </summary>
        /// <value>
        /// The count of items stored in the cache.
        /// </value>
        public abstract int Size { get; }

        /// <summary>
        /// Gets the stored cache keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public abstract string[] Keys { get; }

        /// <summary>
        /// Tries to get the value from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <c>true</c> if the value exists on the cache, otherwise <c>false</c>.
        /// </returns>
        public abstract bool TryGetValue(string key, Type type, out object value);

        /// <summary>
        /// Stores the object on the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The object type to store.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        public abstract void SetValue(string key, Type type, object value, CacheOptions options = null);

        /// <summary>
        /// Determines whether the specified key exists on the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key exists; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool Contains(string key);

        /// <summary>
        /// Deletes the specified key from the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     <c>true</c> if the key was succesfully removed; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool Remove(string key);

        /// <summary>
        /// Removes all the keys from the cache.
        /// </summary>
        public abstract void FlushAll();
    }
}
