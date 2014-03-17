using System;
using System.Collections.Generic;

namespace Cachengue.Providers
{
    /// <summary>
    /// A class that takes care of managing expirations for cache providers that do not have any way of handle them
    /// </summary>
    [Serializable]
    public sealed class InMemoryCacheExpirations : ICacheExpirations
    {
        private readonly Dictionary<string, DateTime> _expirations = new Dictionary<string, DateTime>();

        /// <summary>
        /// Sets the expiration for a key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expirationSeconds">The expiration seconds.</param>
        public void SetExpiration(string key, int expirationSeconds)
        {
            _expirations[key] = DateTime.UtcNow.AddSeconds(expirationSeconds);
        }

        /// <summary>
        /// Checks if the key has expired.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the key has expired; otherwise <c>false</c>.</returns>
        public bool KeyHasExpired(string key)
        {
            if (_expirations.ContainsKey(key))
            {
                var expiration = _expirations[key];
                if (expiration < DateTime.UtcNow)
                {
                    _expirations.Remove(key);
                    return true;
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Remoes all stored expirations.
        /// </summary>
        public void Clear()
        {
            _expirations.Clear();
        }
    }
}