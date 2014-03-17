using System;

namespace Cachengue
{
    /// <summary>
    /// Defines the contract for a cache dependency
    /// </summary>
    public interface ICacheDependency: IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether the dependency has changed.
        /// </summary>
        /// <value>
        /// <c>true</c> if the dependency has changed; otherwise, <c>false</c>.
        /// </value>
        bool HasChanged { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ICacheDependency" /> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; }
    }
}
