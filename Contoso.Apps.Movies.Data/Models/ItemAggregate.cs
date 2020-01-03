using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class ItemAggregate 
    {
        public string id { get; set; }

        [ScaffoldColumn(false)]
        public int ItemId { get; set; }

        public int BuyCount { get; set; }
        public int ViewDetailsCount { get; set; }
        public int AddToCartCount { get; set; }
        public int VoteCount { get; set; }

    }

}