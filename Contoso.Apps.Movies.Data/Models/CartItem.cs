using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Contoso.Apps.Movies.Data.Models
{
    public class CartItem
    {
        [Key]
        public string CartItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public int ItemId { get; set; }

        [NotMapped]
        public virtual Item Product { get; set; }
    }
}