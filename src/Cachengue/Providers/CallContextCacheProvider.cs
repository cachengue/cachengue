using System;
using System.Runtime.Remoting.Messaging;

namespace Cachengue.Providers
{
    /// <summary>
    /// The base class for all context cache providers
    /// </summary>
    public sealed class CallContextCacheProvider : ContextCacheProvider
    {
        /// <summary>
        /// Gets or adds and gets a type from the context
        /// </summary>
        /// <typeparam name="TContextData">The type of the context data.</typeparam>
        /// <param name="key">The context key</param>
        /// <param name="constructorArgs">The constructor arguments</param>
        /// <returns>
        /// The stored value from the context
        /// </returns>
        protected override TContextData GetOrAddFromContext<TContextData>(string key, params object[] constructorArgs)
        {
            key = key + GetHashCode();

            var data = CallContext.GetData(key) as TContextData;

            if (data == null)
            {
                data = LambdaActivator.CreateInstance<TContextData>(constructorArgs);
                CallContext.SetData(key, data);
            }

            return data;
        }
    }
}
