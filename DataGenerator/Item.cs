using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class Item
    {
        [ScaffoldColumn(false)]
        public int ItemId { get; set; }

        public int VoteCount { get; set; }

        public string ProductName { get; set; }

        public int? ImdbId { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string ThumbnailPath { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? CategoryId { get; set; }

        public decimal? Popularity { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? VoteAverage { get; set; }
    }

    // This class is used to compare two objects of type Product to remove 
    // all objects that are duplicates, as determined by the ProductID field.
    public class ProductsComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            if (x.ItemId == y.ItemId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Item obj)
        {
            return obj.ItemId.GetHashCode();
        }
    }
}