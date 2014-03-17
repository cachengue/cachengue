using System.Collections.Generic;
using System.Runtime.Caching;

namespace Cachengue.Providers.Runtime
{
    /// <summary>
    /// A filesystem runtime cache dependency
    /// </summary>
    public class FileCacheDependency : RuntimeCacheDependency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileCacheDependency"/> class.
        /// </summary>
        /// <param name="filePaths">The file paths.</param>
        public FileCacheDependency(IList<string> filePaths)
            : base(new HostFileChangeMonitor(filePaths))
        {
        }
    }
}
