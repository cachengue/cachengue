using System.Linq;
using System.Reflection;
using Cachengue.DesignByContract;

namespace Cachengue
{
    /// <summary>
    /// Useful extensions for the ICacheProvider interface
    /// </summary>
    public static class CacheProviderExtensions
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T">The type of the value to get</typeparam>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <returns>The cached value if exists or the type default's value</returns>
        public static T GetValue<T>(this CacheProviderBase provider, string key)
        {
            return GetValue(provider, key, default(T));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T">The type of the value to get</typeparam>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The cached value if exists or the specified default value</returns>
        public static T GetValue<T>(this CacheProviderBase provider, string key, T defaultValue)
        {
            object cachedValue;

            if (provider.TryGetValue(key, typeof(T), out cachedValue))
            {
                return (T)cachedValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <typeparam name="T">The type of the value to set</typeparam>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        public static void SetValue<T>(this CacheProviderBase provider, string key, T value, CacheOptions options = null)
        {
            provider.SetValue(key, typeof(T), value, options);
        }
    }
}
