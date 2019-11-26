using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class Rule
    {
        public string id { get; set; }

        public int? source { get; set; }

        public double support { get; set; }

        public int? target { get; set; }

        public double confidence { get; set; }
    }
}