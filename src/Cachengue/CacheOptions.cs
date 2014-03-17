using System;
using System.Collections.Generic;
using Cachengue.Configuration;

namespace Cachengue
{
    /// <summary>
    /// Specifies options for a cache store
    /// </summary>
    public class CacheOptions
    {
        /// <summary>
        /// No expiration value
        /// </summary>
        public static readonly int NoExpirationSeconds = CachingConfiguration.Current.DefaultAbsoluteExpirationSeconds;

        private int _expirationSeconds = NoExpirationSeconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOptions" /> class.
        /// </summary>
        public CacheOptions()
        {
            Priority = CacheItemPriority.Normal;
            Dependencies = new List<ICacheDependency>();
        }

        /// <summary>
        /// Gets or sets the expiration seconds.
        /// </summary>
        /// <value>
        /// The expiration seconds.
        /// </value>
        public int ExpirationSeconds
        {
            get { return _expirationSeconds; }
            set { _expirationSeconds = value <= 0 ? NoExpirationSeconds : value; }
        }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        public CacheItemPriority Priority { get; set; }

        /// <summary>
        /// Gets the dependencies.
        /// </summary>
        /// <value>
        /// The dependencies.
        /// </value>
        public IList<ICacheDependency> Dependencies { get; private set; }

        /// <summary>
        /// Gets or sets the updated callback.
        /// </summary>
        /// <value>
        /// The updated callback.
        /// </value>
        public Action<string, object> UpdateCallback { get; set; }

        /// <summary>
        /// Gets or sets the removed callback.
        /// </summary>
        /// <value>
        /// The removed callback.
        /// </value>
        public Action<string, object> RemovedCallback { get; set; }
    }
}
