using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using Newtonsoft.Json;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class CollectorLog
    {
        public string id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "itemId")]
        public int? ItemId { get; set; }

        [JsonProperty(PropertyName = "contentId")]
        public int? ContentId { get; set; }

        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }

        [JsonProperty(PropertyName = "orderid")]
        public int? OrderId { get; set; }

        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }
}