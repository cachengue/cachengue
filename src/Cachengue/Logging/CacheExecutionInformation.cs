using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cachengue.Logging
{
    /// <summary>
    /// Logging information for the current cache execution call
    /// </summary>
    public class CacheExecutionInformation
    {
        /// <summary>
        /// Empty cache execution information
        /// </summary>
        public static readonly CacheExecutionInformation Empty = new CacheExecutionInformation();

        /// <summary>
        /// Gets or sets the cache key.
        /// </summary>
        /// <value>
        /// The cache key.
        /// </value>
        public string CacheKey { get; set; }

        /// <summary>
        /// Gets or sets the caller method.
        /// </summary>
        /// <value>
        /// The caller method.
        /// </value>
        public MethodBase CallerMethod { get; set; }
        
        /// <summary>
        /// Gets or sets the target method.
        /// </summary>
        /// <value>
        /// The target method.
        /// </value>
        public MethodBase TargetMethod { get; set; }
        
        /// <summary>
        /// Gets or sets the target arguments.
        /// </summary>
        /// <value>
        /// The target arguments.
        /// </value>
        public IEnumerable<object> TargetParameters { get; set; }

        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        /// <value>
        /// The return value.
        /// </value>
        public object ReturnValue { get; set; }
        
        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>
        /// The stack trace.
        /// </value>
        public StackTrace StackTrace { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(CacheKey))
            {
                output.AppendFormat("Cache Key: {0}", CacheKey);
                output.AppendLine();
            }

            if (CallerMethod != null)
            {
                output.AppendFormat("Caller Method: {0}.{1}", CallerMethod.DeclaringType, CallerMethod.Name);
                output.AppendLine();
            }

            if (TargetMethod != null)
            {
                output.AppendFormat("Target Method: {0}.{1}", TargetMethod.DeclaringType, TargetMethod.Name);
                output.AppendLine();
            }

            if (TargetParameters != null)
            {
                output.AppendFormat("Target Parameters: {0}", FormatParameters(TargetParameters));
                output.AppendLine();
            }

            if (ReturnValue != null)
            {
                output.AppendFormat("Return Value: {0}", ReturnValue);
                output.AppendLine();
            }

            if (StackTrace != null)
            {
                output.AppendFormat("Stack Trace: {0}", StackTrace);
                output.AppendLine();
            }

            return output.ToString();
        }

        private static string FormatParameters(IEnumerable<object> targetParameters)
        {
            return string.Join(", ", targetParameters.Select(x => x != null ? x.ToString() : string.Empty));
        }
    }
}
