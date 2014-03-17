using System;
using Cachengue.Configuration;
using Cachengue.DesignByContract;
using SerializationProviders;

namespace Cachengue
{
    /// <summary>
    /// A static helper to perform cache items serialization / deserialization 
    /// </summary>
    public class DefaultCacheSerializer : ICacheSerializer
    {
        /// <summary>
        /// A singleton instance for the serializer
        /// </summary>
        public static readonly DefaultCacheSerializer Instance = new DefaultCacheSerializer();

        /// <summary>
        /// Prevents a default instance of the <see cref="DefaultCacheSerializer"/> class from being created.
        /// </summary>
        private DefaultCacheSerializer()
        {
            CacheSettings = CachingConfiguration.Current;
        }

        /// <summary>
        /// Gets or sets the cache settings.
        /// </summary>
        /// <value>
        /// The cache settings.
        /// </value>
        public ICacheSettings CacheSettings { get; set; }

        /// <summary>
        /// Serializes the object
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The string representation of the serialized object
        /// </returns>
        public string SerializeObject(string key, Type type, object value)
        {
            Check.Require<ArgumentNullException>(value != null, "The target cannot be null");
            Check.Require<ArgumentNullException>(type != null, "The type cannot be null");

            return SerializationHelper.SerializeAsBase64String(type, value, GetSerializationProviderName());
        }

        /// <summary>
        /// Deserializes the string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <param name="serialized">The serialized object.</param>
        /// <returns>
        /// The deserialized object
        /// </returns>
        public object DeserializeObject(string key, Type type, string serialized)
        {
            Check.Require<ArgumentNullException>(serialized != null, "The serialized cannot be null");
            Check.Require<ArgumentNullException>(type != null, "The type cannot be null");

            return SerializationHelper.DeserializeFromBase64String(type, serialized, GetSerializationProviderName());
        }

        protected virtual string GetSerializationProviderName()
        {
            return CacheSettings.Serializer;
        }
    }
}
