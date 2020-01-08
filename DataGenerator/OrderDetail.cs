using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class OrderDetail
    {
        //[JsonIgnore]
        //public int OrderDetailId { get; set; }

        //[JsonIgnore]
        //public int OrderId { get; set; }

        // Using the customer's email address instead of username, since we're bypassing authentication for this demo.
        public string Email { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}