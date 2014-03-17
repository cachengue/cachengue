using System;
using System.Collections.Generic;
using System.Linq;

namespace Cachengue
{
    public static class CachengueDependencyResolver
    {
        internal static Func<Type, string, object> Resolver = (type, name) =>
        {
            if (_defaults.ContainsKey(type))
            {
                return _defaults[type];
            }

            if (typeof(CacheProviderBase).IsAssignableFrom(type))
            {
                return string.IsNullOrWhiteSpace(name)
                    ? CacheProviderFactory.Instance.GetProviders().FirstOrDefault(p => p.GetType() == type)
                    : CacheProviderFactory.Instance.GetProvider(name);
            }

            return LambdaActivator.CreateInstance(type);
        };

        private static readonly IDictionary<Type, object> _defaults = new Dictionary<Type, object>
            {
                    { typeof(ICacheSerializer), DefaultCacheSerializer.Instance },
                    { typeof(ICacheProviderFactory), CacheProviderFactory.Instance }
            };
        
        public static void SetResolver(Func<Type, string, object> resolver)
        {
            Resolver = resolver;
        }

        public static object GetService(Type type)
        {
            return Resolver(type, null);
        }

        public static T GetService<T>()
        {
            return (T)Resolver(typeof(T), null);
        }

        public static object GetService(Type type, string name)
        {
            return Resolver(type, name);
        }

        public static object GetService<T>(string name)
        {
            return Resolver(typeof(T), name);
        }
    }
}
