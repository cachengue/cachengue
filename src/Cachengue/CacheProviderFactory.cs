using System;
using System.Collections.Generic;
using Cachengue.Configuration;
using Cachengue.Providers;
using Cachengue.Providers.Runtime;
using ProviderModel;

namespace Cachengue
{
    /// <summary>
    /// The default cache provider factory
    /// </summary>
    public class CacheProviderFactory : ProviderFactory<CacheProviderBase>, ICacheProviderFactory
    {
        private static readonly CacheProviderFactory _defaultInstance = new CacheProviderFactory((type, name) => CachengueDependencyResolver.Resolver(type, name) as CacheProviderBase);

        public CacheProviderFactory(Func<Type, string, CacheProviderBase> instanceResolver)
            : base(instanceResolver)
        {
        }

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        /// <value>
        /// The default instance.
        /// </value>
        public static CacheProviderFactory Instance
        {
            get
            {
                return _defaultInstance;
            }
        }

        /// <summary>
        /// Gets the name of the configuration section.
        /// </summary>
        /// <value>
        /// The name of the configuration section.
        /// </value>
        protected override string ConfigurationSectionName
        {
            get { return CachingSectionHandler.SECTION_NAME; }
        }

        /// <summary>
        /// Initializes the providers when no configuration is found in the application configuration file.
        /// </summary>
        /// <returns>
        /// A list of providers
        /// </returns>
        protected override IEnumerable<KeyValuePair<string, Lazy<CacheProviderBase>>> GetDefaultProvidersWithoutConfiguration()
        {
            yield return new KeyValuePair<string, Lazy<CacheProviderBase>>("memory", new Lazy<CacheProviderBase>(() => new MemoryCacheProvider()));
            yield return new KeyValuePair<string, Lazy<CacheProviderBase>>("null", new Lazy<CacheProviderBase>(() => new NullCacheProvider()));
            yield return new KeyValuePair<string, Lazy<CacheProviderBase>>("context", new Lazy<CacheProviderBase>(() => new CallContextCacheProvider()));
            yield return new KeyValuePair<string, Lazy<CacheProviderBase>>("runtime", new Lazy<CacheProviderBase>(() => new RuntimeCacheProvider()));
        }
    }
}