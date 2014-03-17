using System.Data.SqlClient;
using System.Runtime.Caching;

namespace Cachengue.Providers.Runtime
{
    /// <summary>
    /// A sql server runtime cache dependency
    /// </summary>
    public class SqlCacheDependency : RuntimeCacheDependency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCacheDependency"/> class.
        /// </summary>
        /// <param name="sqlDependency">The SQL dependency.</param>
        public SqlCacheDependency(SqlDependency sqlDependency)
            : base(new SqlChangeMonitor(sqlDependency))
        {
        }
    }
}
