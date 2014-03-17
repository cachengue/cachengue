using System.Runtime.Caching;

namespace Cachengue.Providers.Runtime
{
    /// <summary>
    /// Base class for all Runtime cache dependencies
    /// </summary>
    public abstract class RuntimeCacheDependency : ICacheDependency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeCacheDependency"/> class.
        /// </summary>
        /// <param name="wrappedChangeMonitor">The wrapped change monitor.</param>
        protected RuntimeCacheDependency(ChangeMonitor wrappedChangeMonitor)
        {
            ChangeMonitor = wrappedChangeMonitor;
        }

        /// <summary>
        /// Gets the change monitor.
        /// </summary>
        /// <value>
        /// The change monitor.
        /// </value>
        public ChangeMonitor ChangeMonitor { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the dependency has changed.
        /// </summary>
        /// <value>
        /// <c>true</c> if the dependency has changed; otherwise, <c>false</c>.
        /// </value>
        public bool HasChanged
        {
            get { return ChangeMonitor.HasChanged; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ICacheDependency" /> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled
        {
            get
            {
                return !ChangeMonitor.IsDisposed;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!ChangeMonitor.IsDisposed)
            {
                ChangeMonitor.Dispose();
            }
        }
    }
}
