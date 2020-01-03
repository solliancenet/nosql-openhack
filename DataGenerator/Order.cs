using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int OrderId { get; set; }

        /// <summary>
        /// Identifies the Event Hub region to which this message was sent.
        /// </summary>
        public string Region { get; set; }

        public System.DateTime OrderDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public bool SMSOptIn { get; set; }

        public string SMSStatus { get; set; }

        public string Email { get; set; }

        public string ReceiptUrl { get; set; }

        public decimal Total { get; set; }

        public string PaymentTransactionId { get; set; }

        public bool HasBeenShipped { get; set; }

        [JsonProperty("Details")]
        [NotMapped]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}