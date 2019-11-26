using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    //[NotMapped]
    public class SimilarItem //: Item
    {
        public string id { get; set; }
        public double similarity { get; set; }

        public int? sourceItemId { get; set; }
        public int? targetItemId { get; set; }

        public int Target { get; set; }

        //new public string EntityType { get { return "Item"; } }
    }

    
}