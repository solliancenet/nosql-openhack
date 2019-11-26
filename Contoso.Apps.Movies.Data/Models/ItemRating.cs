using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class ItemRating
    {
        public string id { get; set; }

        [JsonProperty(PropertyName = "itemId")]
        public int ItemId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public double Rating { get; set; }

        [JsonProperty(PropertyName = "ratingTimestamp")]
        public DateTime RatingTimestamp { get; set; }
    }
}