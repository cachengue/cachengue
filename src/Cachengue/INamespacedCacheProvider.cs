namespace Cachengue
{
    /// <summary>
    /// Defines the contract for cache providers that have namespace support
    /// </summary>
    public interface INamespacedCacheProvider
    {
        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        /// <value>
        /// The namespace.
        /// </value>
        string Namespace { get; set; }

        /// <summary>
        /// Determines whether the key has the namespace applied
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if they key has the namespace applied; otherwise, <c>false</c>.
        /// </returns>
        bool IsKeyNamespaced(string key);

        /// <summary>
        /// Gets the key with the namespace applied.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The key with the namespace applied</returns>
        string GetNamespacedKey(string key);
    }
}
