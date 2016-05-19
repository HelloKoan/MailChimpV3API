using Newtonsoft.Json;

namespace MailChimpV3API
{
    public abstract class MailChimpCollectionFilterBase : MailChimpFieldFilter
    {
        protected MailChimpCollectionFilterBase()
        {
            Offset = 0;
            Count = 10;
        }

        /// <summary>
        ///     The number of instances returned for one query.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        ///     The number of instances to skip from the beginning of the collection.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        public abstract MailChimpCollectionFilterBase Clone();
    }
}
