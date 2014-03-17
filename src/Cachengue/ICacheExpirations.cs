namespace Cachengue
{
    /// <summary>
    /// Defines the contract for all cache expiration manager
    /// </summary>
    public interface ICacheExpirations
    {
        /// <summary>
        /// Sets the expiration for a key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expirationSeconds">The expiration seconds.</param>
        void SetExpiration(string key, int expirationSeconds);

        /// <summary>
        /// Checks if the key has expired.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the key has expired; otherwise <c>false</c>.</returns>
        bool KeyHasExpired(string key);

        /// <summary>
        /// Remoes all stored expirations.
        /// </summary>
        void Clear();
    }
}
