using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        // Using the customer's email address instead of username, since we're bypassing authentication for this demo.
        public string Email { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Calculated field (read only) that returns the cost based on quantity * price.
        /// </summary>
        [ReadOnly(true)]
        public decimal Cost
        {
            get
            {
                decimal unitPrice = UnitPrice ?? 0;
                return Decimal.Round(unitPrice * Quantity, 2);
            }
        }

        [NotMapped]
        [ReadOnly(true)]
        public Item Product { get; set; }
    }
}